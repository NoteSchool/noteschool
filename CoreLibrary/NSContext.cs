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

        readonly Dictionary<string,Group> _groups;

        readonly Dictionary<string,User> _users;

        public NSContext()
        {
            _groups = new Dictionary<string,Group>();
            _users = new Dictionary<string, User>();
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
            if (services == null) throw new ArgumentNullException("services");
            _services = services;
        }

        public Group FindOrCreateGroup(string name, string tag, out bool created)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must be a non empty string", "name");
            created = false;
            Group g;
            if (!_groups.TryGetValue(name, out g))
            {
                g = new Group(this, name, tag);
                _groups.Add(name, g);
                created = true;
            }
            return g;
        }
        public User CreateUser(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName)) throw new ArgumentException( "Must be a non empty string", "firstName" );
            if (String.IsNullOrWhiteSpace(lastName)) throw new ArgumentException( "Must be a non empty string", "lastName" );

            string id = Guid.NewGuid().ToString( "N" );

            User u = new User( this, firstName, lastName, id);

            _users.Add(id, u);

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
        public Group FindGroupByName(string name)
        {
            Group g;
            _groups.TryGetValue(name, out g);
            return g;
        }

        public void Save()
        {
            Services.Repository.Save(this);
        }

        public static NSContext Load( NSContextServices services )
        {
            NSContext c = services.Repository.LoadUnitializedContext();
            c.Initialize(services); 
            return c;
        }
        public void Receive()
        {
       //     Services.Lan.InitializeReceiver();
        }


    }
}
