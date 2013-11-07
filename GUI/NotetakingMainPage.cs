using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.Net;

namespace GUI
{
    public partial class NotetakingMainPage : UserControl
    {
        public event EventHandler ButtonLeaveGroups;

        #region NETWORK
        delegate void AddMessage(string message);


        const int _port = 2222;

        //BROADCOAST
        const string broadcastAddress = "255.255.255.255";

        UdpClient _receivingClient;
        UdpClient _sendingClient;
        string _ip;

        Thread _receivingThread;

        #endregion


        public NotetakingMainPage()
        {
            InitializeComponent();
            btnLeaveGroup.Click += new EventHandler(btnLeaveGroup_Click);

            Sender();
            //ON TEST PURPOSE ONLY
            //NEED TO create delegate and use INVOKE.
            CheckForIllegalCrossThreadCalls = false;
            
            InitializeReceiver();

            //Timer for the synchronization
            System.Timers.Timer _syncTimer = new System.Timers.Timer();
            _syncTimer.Elapsed += new ElapsedEventHandler(SyncTimer);

            //Interval in milliseconds
            _syncTimer.Interval = 2000;
            _syncTimer.Enabled = true;
             
        }

        private void SyncTimer(object sender, ElapsedEventArgs e)
        {
            string note = rtbNoteTaking.Text;

            //convert string to bytes (needed to be able to send)
            byte[] data = Encoding.ASCII.GetBytes(note);

            //send the data (multicast)
            // _sendingClient.Send(data, data.Length, Sender());
            _sendingClient.Send(data, data.Length);
        }

        public void Sender()
        {
            _sendingClient = new UdpClient(broadcastAddress, _port);
            _sendingClient.EnableBroadcast = true;
        }
        #region MULTICAST
        public IPEndPoint SenderMulticast()
        {
            _sendingClient = new UdpClient();

            //get local ip address in string
            _ip = LocalIPAddress();

            //convert string to ip address format
            IPAddress _multicastadress = IPAddress.Parse(_ip);

            //insert local ip to a multicast group
            _sendingClient.JoinMulticastGroup(_multicastadress);

            //create an IPEndPoint which contains IP address and port
            IPEndPoint localEndPoint = new IPEndPoint(_multicastadress, _port);
            
            return localEndPoint;
        }
        #endregion

        private void InitializeReceiver()
        {
            _receivingClient = new UdpClient();

            //multicast
            /*
            //set option to get multiple receive on a single machine
            _receivingClient.ExclusiveAddressUse = false;
            _receivingClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _receivingClient.ExclusiveAddressUse = false;
            */
           
            ThreadStart start = new ThreadStart(Receiver);
            _receivingThread = new Thread(start);
            _receivingThread.IsBackground = true;
            _receivingThread.Start();
             
        }
        private void Receiver()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, _port);
            AddMessage messageDelegate = MessageReceived;
            _receivingClient.Client.Bind(endPoint);

            while (true)
            {
                byte[] data = _receivingClient.Receive(ref endPoint);
                string message = Encoding.ASCII.GetString(data);
                Invoke(messageDelegate, message);
            }
        }
        private void MessageReceived(string message)
        {
            rtbReadOnly.Text = message;
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void btnLeaveGroup_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (ButtonLeaveGroups != null)
                ButtonLeaveGroups(this, e); 
        }

    }
}
