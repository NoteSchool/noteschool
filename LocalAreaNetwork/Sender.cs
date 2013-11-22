using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LocalAreaNetwork
{
    public partial class LAN : ILocalAreaNetwork
    {
        /*
        UdpClient _sendingClient;
        System.Timers.Timer _syncTimer;
        IPAddress _multicastadress;
        static IPAddress dada = IPAddress.Parse("224.0.1.0");
        IPEndPoint waitingGroupEndPoint = new IPEndPoint(dada, _port);
        string _multicastAddress;

        private void Timer()
        {
            //Create a new timer
            _syncTimer = new System.Timers.Timer();
            _syncTimer.Elapsed += new ElapsedEventHandler(SyncTimer);

            //Interval in milliseconds
            _syncTimer.Interval = 100;
            _syncTimer.Enabled = true;
        }

        private void SyncTimer(object sender, ElapsedEventArgs e)
        {
            try
            {
                // get note from the form
                Invoke(new Action(GetNote));

                //convert string to bytes (needed to be able to send)
                byte[] data = Encoding.ASCII.GetBytes(_note);

                //send the data to the multicastgroup
                _sendingClient.Send(data, data.Length, Sender());

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
        private IPEndPoint Sender()
        {
            _sendingClient = new UdpClient();

            //if multicast address does not exist, create a new one
            if (_mca == null)
            {
                _mca = MulticastGroupAddress();
            }

            //convert string to ip address format
            _multicastadress = IPAddress.Parse(_mca);

            //insert local multicast address to a multicast group
            _sendingClient.JoinMulticastGroup(_multicastadress);

            //create an IPEndPoint which contains IP address and port
            IPEndPoint localEndPoint = new IPEndPoint(_multicastadress, _port);

            return localEndPoint;
        }
        //create new multicast adress from 224.0.1.1 to 239.255.255.255
        // multicast address for waiting group: 224.0.1.0
        private string MulticastGroupAddress()
        {
            Random rnd = new Random();
            int _1stByte = rnd.Next(224, 240);
            int _2ndByte = rnd.Next(0, 256);
            int _3rdByte = rnd.Next(1, 256);
            int _4thByte = rnd.Next(1, 256);

            _multicastAddress = _1stByte + "." + _2ndByte + "." + _3rdByte + "." + _4thByte;

            return _multicastAddress;
        }
        */
    }
}
