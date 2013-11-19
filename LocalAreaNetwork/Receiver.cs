using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalAreaNetwork
{
    public partial class LAN : ILocalAreaNetwork
    {
        UdpClient _receivingClient;
        Thread _receivingThread;
        bool _receiverStatus;
        string _mca;
        public static int _port = 2222;

        private void InitializeReceiver()
        {
            _receivingClient = new UdpClient();

            //ON TEST PURPOSE ONLY
            IPAddress multicastaddress = IPAddress.Parse(_mca);
            _receivingClient.JoinMulticastGroup(multicastaddress);

            //set option to get multiple receiver on a single machine
            _receivingClient.ExclusiveAddressUse = false;
            _receivingClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //start a new thread to listen
            _receivingThread = new Thread(new ThreadStart(Receiver));

            //set receiving thread to the background.
            _receivingThread.IsBackground = true;
            _receivingThread.Start();

        }

        private void Receiver()
        {
            //create an IPEndPoint which contains IP address and port
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, _port);

            //bind the endPoint (needed to receive data)
            _receivingClient.Client.Bind(endPoint);

            while (_receiverStatus)
            {
                try
                {
                    //receive data in bytes
                    byte[] data = _receivingClient.Receive(ref endPoint);

                    //convert bytes to string
                    string message = Encoding.ASCII.GetString(data);

                    // get the ip

                    //need for showing received data in the form
                    Invoke(new Action<string>(MessageReceived), message);
                }
                catch
                {
                }
            }
        }
        //show the received data
        private void MessageReceived(string message)
        {
            rtbReadOnly.Text = _multicastadress + "-" + message;
        }
    }
}
