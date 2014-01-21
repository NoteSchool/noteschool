using CoreLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LocalAreaNetwork
{
    public partial class LAN : ILocalAreaNetwork
    {
        UdpClient _sendingGroupClient = new UdpClient();
        UdpClient _sendingDefaultGroupClient;

        public void InitializeSender(Object obj, Object obj2)
        {
            //create udp sending default client if not existed
            if (_sendingDefaultGroupClient == null)
            {
                _sendingDefaultGroupClient = new UdpClient();
                _sendingDefaultGroupClient.JoinMulticastGroup(_defaultGroupAddress);
            }

            try
            {
                //create an IPEndPoint which contains IP address and port
                IPEndPoint DefaultEndPoint = new IPEndPoint( _defaultGroupAddress, _defaultport );
                IPEndPoint EndPoint = new IPEndPoint( _groupAddress, _port );

                _sendingGroupClient.MulticastLoopback = false;
                _sendingDefaultGroupClient.MulticastLoopback = false;

                //convert string to bytes (needed to be able to send)
                byte[] data = ObjectToByteArray(obj);
                byte[] data2 = ObjectToByteArray(obj2);

                //send byte array to default client
                _sendingDefaultGroupClient.Send(data2, data2.Length, DefaultEndPoint);

                //send byte array to client
                _sendingGroupClient.Send( data, data.Length, EndPoint);
            }
            catch (Exception e)
            {
                Helper.dd("{0} Exception caught. " + e.Message);
            }
        }

        // Convert an object to a byte array
        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
    }
}
