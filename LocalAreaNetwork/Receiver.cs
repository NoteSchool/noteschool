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

        //bool _receiverStatus;
        static int _port = 2222;
        string _data;

        public string InitializeReceiver()
        {
            Thread _receivingThread;

            _receivingClient = new UdpClient();
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
        //receive data
     //   public string Data { get { return _data; } }

        /*
        /// <summary>
        /// Create new multicast address from 224.0.1.1 to 239.255.255.255
        /// Multicast address for waiting group: 224.0.1.0
        /// </summary>
        /// <returns></returns>
        private string MulticastGroupAddress()
        {
            Random rnd = new Random();
            int _1stByte = rnd.Next( 224, 240 );
            int _2ndByte = rnd.Next( 0, 256 );
            int _3rdByte = rnd.Next( 1, 256 );
            int _4thByte = rnd.Next( 1, 256 );

            _multicastAddress = _1stByte + "." + _2ndByte + "." + _3rdByte + "." + _4thByte;

            return _multicastAddress;
        }
         * */
    }
}
