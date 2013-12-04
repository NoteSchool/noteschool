using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CoreLibrary
{
    [Serializable]
    public class NSContext
    {
        [NonSerialized]
        NSContextServices _services;

        readonly Dictionary<string, Group> _groups;
        readonly Dictionary<string, User> _users;
        readonly Dictionary<string, Note> _notes;

        readonly Dictionary<string, List<string>> _userListPerGroup;
        string _sendingData;

        public NSContext()
        {
            _groups = new Dictionary<string, Group>();
            _users = new Dictionary<string, User>();
            _notes = new Dictionary<string, Note>();
            _userListPerGroup = new Dictionary<string,List<string>>();
        }

        public NSContextServices Services
        {
            get
            {
                if (_services == null) throw new InvalidOperationException( "NSContext must be initialized!" );
                return _services;
            }
        }

        public Dictionary<string, Group> Groups { get { return _groups; } }
        public Dictionary<string, User> Users { get { return _users; } }
        public Dictionary<string, Note> Notes { get { return _notes; } }

        public void Initialize( NSContextServices services )
        {
            if (services == null) throw new ArgumentNullException( "services" );
            _services = services;
        }

        public Group FindOrCreateGroup( string name, string tag, string multicastAddress, out bool created )
        {
            if (String.IsNullOrWhiteSpace( name )) throw new ArgumentException( "Must be a non empty string", "name" );
            created = false;
            bool existed = false;
            Group g;
            if (!_groups.TryGetValue( name, out g ))
            {
                while (!created)
                {
                    foreach (var group in _groups)
                    {
                        if (multicastAddress == group.Value.MulticastAddress)
                        {
                            existed = true;
                        }
                    }
                    if (!existed)
                    {
                        g = new Group( this, name, tag, multicastAddress );
                        _groups.Add( name, g );
                        created = true;
                    }
                    else
                    {
                        multicastAddress = SetMulticastAddress();
                        existed = false;
                    }
                }
            }
            return g;
        }

        public Note CreateNote(Group group)
        {
            Note n = new Note(this, group);

            _notes.Add(n.Id, n);
            return n;
        }

        public User CreateUser( string firstName, string lastName )
        {
            if (String.IsNullOrWhiteSpace( firstName )) throw new ArgumentException( "Must be a non empty string", "firstName" );
            if (String.IsNullOrWhiteSpace( lastName )) throw new ArgumentException( "Must be a non empty string", "lastName" );

            User u = new User( this, firstName, lastName);

            _users.Add( u.Id, u );

            return u;
        }
        /*
        public Group CreateGroup(string name, bool autoNumbering = true )
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must be a non empty string", "name");
            string candidateName = name;
            int candidateSuffixNumber = 0;
            while( _groups.ContainsKey(candidateName) )
            {
                candidateName = String.Format("{0} ({1})", name, ++candidateSuffixNumber);
            }
            var g = new Group(this, candidateName );
            _groups.Add(candidateName, g);
            return g;
        }
        */
        public Group FindGroup( string name)
        {
            Group g;
            _groups.TryGetValue( name, out g );
            return g;
        }

        public void Save()
        {
            Services.Repository.Save( this );
        }

        public static NSContext Load( NSContextServices services )
        {
            NSContext c = services.Repository.LoadUnitializedContext();
            c.Initialize( services );
            return c;
        }
        public string Receiver()
        {
            return Services.Lan.InitializeReceiver();
        }
        public void JoinGroup(string mca = "224.0.1.0")
        {
            Services.Lan.JoinGroup(mca);
        }
        public void LeaveGroup( string mca = "224.0.1.0" )
        {
            Services.Lan.LeaveGroup( mca );
        }

        /// <summary>
        /// Create new multicast address from 224.0.1.1 to 239.255.255.255
        /// Multicast address for waiting group: 224.0.1.0
        /// </summary>
        /// <returns></returns>
        public string SetMulticastAddress()
        {
            Random rnd = new Random();
            int _1stByte = rnd.Next( 224, 240 );
            int _2ndByte = rnd.Next( 0, 256 );
            int _3rdByte = rnd.Next( 1, 256 );
            int _4thByte = rnd.Next( 1, 256 );

            string _multicastAddress = _1stByte + "." + _2ndByte + "." + _3rdByte + "." + _4thByte;

            return _multicastAddress;
        }
        public void Timer(string sendingData)
        {
            System.Timers.Timer _syncTimer;

            //Create a new timer
            _syncTimer = new System.Timers.Timer();
            _syncTimer.Elapsed += SyncTimer;

            //Interval in milliseconds
            _syncTimer.Interval = 100;
            _syncTimer.Enabled = true;

            _sendingData = sendingData;

        }  
        private void SyncTimer( object sender, ElapsedEventArgs e )
        {
            Services.Lan.InitializeSender(_sendingData);
        }
    }
}
