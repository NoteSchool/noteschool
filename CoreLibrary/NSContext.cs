using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class NSContext
    {
        [NonSerialized]
        NSContextServices _services;

        readonly Dictionary<string, Group> _groups;
        readonly Dictionary<string, string> _groupslist;
        readonly Dictionary<string, User> _users;

        public NSContext()
        {
            _groups = new Dictionary<string, Group>();
            _users = new Dictionary<string, User>();
            _groupslist = new Dictionary<string,string>();
        }

        public NSContextServices Services
        {
            get
            {
                if (_services == null) throw new InvalidOperationException( "NSContext must be initialized!" );
                return _services;
            }
        }

        public void Initialize( NSContextServices services )
        {
            if (services == null) throw new ArgumentNullException( "services" );
            _services = services;
        }
        public Dictionary<string, Group> GetGroups
        {
            get { return _groups; }
        }

        public Group FindOrCreateGroup( string name, string tag, out bool created )
        {
            if (String.IsNullOrWhiteSpace( name )) throw new ArgumentException( "Must be a non empty string", "name" );
            created = false;
            Group g;
            if (!_groups.TryGetValue( name, out g ))
            {
                while (!created)
                {
                    string _multicastAddress = SetMulticastAddress();

                    if (!_groupslist.ContainsValue( _multicastAddress ))
                    {
                        g = new Group( this, name, tag, _multicastAddress );
                        _groups.Add( name, g );
                        _groupslist.Add( name, _multicastAddress );
                        created = true;
                    }
                }
            }
            return g;
        }
        public Group FindOrCreateGroup( string name, string tag, string multicastAddress)
        {
            if (String.IsNullOrWhiteSpace( name )) throw new ArgumentException( "Must be a non empty string", "name" );
            if (String.IsNullOrWhiteSpace( tag )) throw new ArgumentException( "Must be a non empty string", "tag" );
            if (String.IsNullOrWhiteSpace( multicastAddress )) throw new ArgumentException( "Must be a non empty string", "multicastAddress" );
            bool created = false;
            Group g;
            if (!_groups.TryGetValue( name, out g ))
            {
                while (!created)
                {
                    if (!_groupslist.ContainsValue( multicastAddress ))
                    {
                        g = new Group( this, name, tag, multicastAddress );
                        _groups.Add( name, g );
                        _groupslist.Add( name, multicastAddress );
                        created = true;
                    }
                    else
                        multicastAddress = SetMulticastAddress();
                }
            }
            return g;
        }
        public User CreateUser( string firstName, string lastName )
        {
            if (String.IsNullOrWhiteSpace( firstName )) throw new ArgumentException( "Must be a non empty string", "firstName" );
            if (String.IsNullOrWhiteSpace( lastName )) throw new ArgumentException( "Must be a non empty string", "lastName" );

            string id = Guid.NewGuid().ToString( "N" );

            User u = new User( this, firstName, lastName, id );

            _users.Add( id, u );

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
    }
}
