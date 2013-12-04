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
        UdpClient _receivingClient = new UdpClient();
        Thread _receivingThread;
        IPAddress _multicastAddress;

        //bool _receiverStatus;
        static int _port = 2222;
        string _data;
        const string _mca = "224.0.1.0";

        public string InitializeReceiver()
        {
            /*
            //ON TEST PURPOSE ONLY
            IPAddress _multicastaddress = IPAddress.Parse(_mca);
            _receivingClient.JoinMulticastGroup(_multicastaddress);
            */

            //set option to get multiple receiver on a single machine
            _receivingClient.ExclusiveAddressUse = false;
            _receivingClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //start a new thread to listen
            _receivingThread = new Thread(new ThreadStart(Receiver));

            //set receiving thread to the background.
            _receivingThread.IsBackground = true;
            _receivingThread.Start();

            return _data;
        }

        private void Receiver()
        {
            //create an IPEndPoint which contains IP address and port
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, _port);

            //bind the endPoint (needed to receive data)
            _receivingClient.Client.Bind(endPoint);

            //while (_receiverStatus)
            while (true)
            {
                try
                {
                    //receive data in bytes
                    byte[] data = _receivingClient.Receive(ref endPoint);

                    //convert bytes to string
                    _data = Encoding.ASCII.GetString( data );

                }
                catch
                {
                }
            }
        }
        public void JoinGroup( string mca = _mca)
        {
            _multicastAddress = IPAddress.Parse(mca);
            _receivingClient.JoinMulticastGroup( _multicastAddress );

            if(mca != _mca)
                _sendingClient.JoinMulticastGroup( _multicastAddress );
        }
        public void LeaveGroup( string mca = _mca)
        {
            _multicastAddress = IPAddress.Parse( mca );
            _receivingClient.DropMulticastGroup( _multicastAddress );

            if (mca != _mca)
            {
                _sendingClient.DropMulticastGroup( _multicastAddress );
                _sendingClient.Close();
            }

          //  _receivingThread.Abort();
            //_receivingClient.Close();

        }

        //receive data
     //   public string Data { get { return _data; } }


    }
}
