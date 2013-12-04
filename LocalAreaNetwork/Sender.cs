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
        UdpClient _sendingClient = new UdpClient();
        /*
        System.Timers.Timer _syncTimer;
        IPAddress _multicastadress;
        static IPAddress dada = IPAddress.Parse("224.0.1.0");
        IPEndPoint waitingGroupEndPoint = new IPEndPoint(dada, _port);
        string _multicastAddress;
        */
        public LAN()
        {
           
        }

        /*
        private void Timer()
        {
            //Create a new timer
            _syncTimer = new System.Timers.Timer();
            _syncTimer.Elapsed += new ElapsedEventHandler(SyncTimer);

            //Interval in milliseconds
            _syncTimer.Interval = 100;
            _syncTimer.Enabled = true;
        }
        */

        public void InitializeSender(string sendingData)
        {
            try
            {
                //convert string to bytes (needed to be able to send)
                byte[] _groupData = Encoding.ASCII.GetBytes(sendingData);
             //   byte[] _noteData = Encoding.ASCII.GetBytes(sendingData);

                //send the data to the multicastgroup
                _sendingClient.Send( _groupData, _groupData.Length, GroupSender() );
         //       _sendingClient.Send( _noteData, _noteData.Length, NoteSender() );

            }
            catch
            {
            }
        }
        /*
        private void teler()
        {
          
            string[] groupdata = { "name", "tag" , "address" }; 
            byte[] array = BitConverter.GetBytes(groupdata);;

            _sendingClient.Send();

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize( stream, objectToSerialize );
                serializedObject = stream.ToArray();
            }

        }*/
                /*
                //TODO:
                byte[] _mcaData = Encoding.ASCII.GetBytes("Name" + "tag" + _mca);
                _sendingClient.Send(_mcaData, _mcaData.Length, waitingGroupEndPoint);

                //send the group's data to the waiting group
                //need to create an enpoint for the waiting group
                // 
            }
            catch
            {
            }
        }
                 * */
        private IPEndPoint NoteSender()
        {
            //create an IPEndPoint which contains IP address and port
            IPEndPoint localEndPoint = new IPEndPoint( _multicastAddress, _port );

            return localEndPoint;
        }
        private IPEndPoint GroupSender()
        {
            //create an IPEndPoint which contains IP address and port
            IPEndPoint localEndPoint = new IPEndPoint( _multicastAddress, _port );

            return localEndPoint;
        }
    }
}
