using CoreLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalAreaNetwork
{
    public partial class LAN : ILocalAreaNetwork
    {
        UdpClient _receivingGroupClient = new UdpClient();
        IPAddress _groupAddress;

        UdpClient _receivingDefaultGroupClient;
        IPAddress _defaultGroupAddress = IPAddress.Parse( "224.0.1.0" );

        Thread _receivingThread;

        static int _port = 2222;
        static int _defaultport = 3333;

        bool _receiverStatus;

        Object _groupData;
        Object _defaultGroupData;

        public void InitializeReceiver()
        {
            // DEFAULT
            if (_receivingDefaultGroupClient == null)
            {
                _receivingDefaultGroupClient = new UdpClient();
                _receivingDefaultGroupClient.JoinMulticastGroup( _defaultGroupAddress );

                _receivingDefaultGroupClient.ExclusiveAddressUse = false;
                _receivingDefaultGroupClient.Client.SetSocketOption( SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true );
            }
            
            //start a new thread to listen
            _receivingThread = new Thread( new ThreadStart( Receiver ) );

            //set receiving thread to the background.
            _receivingThread.IsBackground = true;
            _receivingThread.Start();
        }

        private void Receiver()
        {
            //create an IPEndPoint which contains IP address and port
            IPEndPoint EndPoint = new IPEndPoint(IPAddress.Any, _port);
            IPEndPoint DefaultEndPoint = new IPEndPoint( IPAddress.Any, _defaultport );
            
            //bind the client (need to be able to receive)
            _receivingDefaultGroupClient.Client.Bind( DefaultEndPoint );
            _receivingGroupClient.Client.Bind( EndPoint );
            _receivingGroupClient.MulticastLoopback = false;
            _receivingDefaultGroupClient.MulticastLoopback = false;
            _receiverStatus = true;

            byte[] _groupDataBytes;
            byte[] _defaultGroupDataBytes;

            while (_receiverStatus)
            {
                //try
                //{
                    if (_groupAddress != null)
                    {
                        _groupDataBytes = _receivingGroupClient.Receive( ref EndPoint );                      
                        _groupData = ByteArrayToObject(_groupDataBytes);
                    }

                    _defaultGroupDataBytes = _receivingDefaultGroupClient.Receive( ref DefaultEndPoint );
                    _defaultGroupData = ByteArrayToObject( _defaultGroupDataBytes );
                //}
                //catch (Exception e)
                //{
                    //Console.WriteLine( "{0} Exception caught.", e );
                //}
            }
        }

        public void JoinGroup( string mca )
        {
            //convert string to IPAddress
            _groupAddress = IPAddress.Parse( mca );

            //receiving client join current group multicast address
            _receivingGroupClient.JoinMulticastGroup( _groupAddress );

            //sending client join current group multicast address
            _sendingGroupClient.JoinMulticastGroup( _groupAddress );

        }

        public void LeaveGroup( string mca )
        {
            //convert string to IPAddress
            _groupAddress = IPAddress.Parse( mca );

            //receiving client leave current group multicast address
            _receivingGroupClient.DropMulticastGroup( _groupAddress );

            //sending client leave current group multicast address
            _sendingGroupClient.DropMulticastGroup( _groupAddress );
        }

        // Convert a byte array to an Object
        private Object ByteArrayToObject( byte[] arrBytesZipped )
        {
            byte[] arrBytes = Helper.Unzip(arrBytesZipped);
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write( arrBytes, 0, arrBytes.Length );
            memStream.Seek( 0, SeekOrigin.Begin );
            Object obj = (Object)binForm.Deserialize( memStream );
            return obj;
        }
        
        public Object GroupData()
        {
            return _groupData;
        }
        public Object DefaultGroupData()
        {
            return _defaultGroupData;
        }

        //TODO : close methode

        /*
        _receivingThread.Abort();
        _receivingThread.Join();
        _receivingClient.Close();
        _sendingClient.Close();
        */
    }
}
