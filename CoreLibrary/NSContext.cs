using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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

        Dictionary<string, Group> _groups;
        readonly Dictionary<string, User> _users;
        readonly Dictionary<string, Note> _notes;

        private User _currentUser;

        [NonSerialized]
        private Group _currentGroup;

        //TODO group list to add
        private Group _listgroup;

        readonly Dictionary<string, List<string>> _userListPerGroup;

        [NonSerialized]
        private string _currentMca;

        public NSContext()
        {
            _groups = new Dictionary<string, Group>();
            _users = new Dictionary<string, User>();
            _notes = new Dictionary<string, Note>();
            _userListPerGroup = new Dictionary<string, List<string>>();
        }

        public NSContextServices Services
        {
            get
            {
                if (_services == null) throw new InvalidOperationException( "NSContext must be initialized!" );
                return _services;
            }
        }

        public Group CurrentGroup 
        { 
            get { return _currentGroup; } 
            set 
            {
                //currentGroup was set before AND currentGroup is different than that one
                if (_currentGroup != null && _currentGroup.MulticastAddress != value.MulticastAddress)
                {
                    Helper.dd("group " + _currentGroup.Name + "(" + _currentGroup.MulticastAddress + ") was leave");
                    LeaveGroup(_currentGroup.MulticastAddress);
                }

                //currentGroup no set yet OR currentGroup is not that one
                if (_currentGroup == null || _currentGroup.MulticastAddress != value.MulticastAddress)
                {
                    Helper.dd("group " + value.Name + "(" + value.MulticastAddress + ") was join");
                    JoinGroup(value.MulticastAddress);
                }
                _currentGroup = value; 
            } 
        }
        public User CurrentUser { get { return _currentUser; } set { _currentUser = value; } }
        public Group ListGroup { get { return _listgroup; } }

        public Dictionary<string, Group> Groups { get { return _groups; } set { _groups = value; } }
        public Dictionary<string, User> Users { get { return _users; } }
        public Dictionary<string, Note> Notes { get { return _notes; } }

        public void Initialize( NSContextServices services )
        {
            if (services == null) throw new ArgumentNullException( "services" );
            _services = services;
        }

        //NEED TO FIX _groups key is a multicast address
        public Group FindOrCreateGroup( string name, string tag, string multicastAddress, out bool created )
        {
            if (String.IsNullOrWhiteSpace( name )) throw new ArgumentException( "Must be a non empty string", "name" );

            created = false;
            Group g = null;

            //_groups looking for a multicast address;
            if (!_groups.TryGetValue(multicastAddress, out g))
            {
                g = new Group( this, name, tag, multicastAddress );
                _groups.Add( multicastAddress, g );
                created = true;
            }

            return g;
        }

        public Group CreateGroupFromPacket(GroupFullPacket group, out bool updated)
        {
            bool created;
            var g = FindOrCreateGroup(group.Name, group.Tag, group.MulticastAddress, out created);
            updated = false;
            if (created)
            {
                g.Notes = group.Notes;
                g.Users = group.Users;
                updated = true;
            }
            else //merge user and notes
            {
                group.Users.ToList().ForEach(x => g.Users[x.Key] = x.Value);
                int compare;

                foreach (var v in group.Notes)
                {
                    //update
                    if (g.Notes.ContainsKey(v.Key))
                    {
                        //different date ?
                        compare = DateTime.Compare(g.Notes[v.Key].EditedAt, v.Value.EditedAt);
                        if ( compare < 0)
                        {
                            g.Notes[v.Key].Text = v.Value.Text;
                            //g.NoteEditedAt = DateTime.Now;
                            g.NoteEditedAt = v.Value.EditedAt;
                            updated = true;
                        }
                    }
                    else //add
                    {
                        g.Notes.Add(v.Key, v.Value);
                        g.NoteEditedAt = DateTime.Now;
                        updated = true;
                    }
                }
            }

            return g;
        }

        public Group CreateGroupFromPacket(GroupLightPacket group)
        {
            bool created;
            return FindOrCreateGroup(group.Name, group.Tag, group.MulticastAddress, out created);
        }

        public User CreateUser( string firstName, string lastName )
        {
            if (String.IsNullOrWhiteSpace( firstName )) throw new ArgumentException( "Must be a non empty string", "firstName" );
            if (String.IsNullOrWhiteSpace( lastName )) throw new ArgumentException( "Must be a non empty string", "lastName" );

            User u = new User( this, firstName, lastName );

            _users.Add( u.Id, u );

            return u;
        }

        public Group FindGroup( string id )
        {
            Group g;
            _groups.TryGetValue( id, out g );
            return g;
        }

        public void Save()
        {
            if (CurrentGroup != null)
            {
                if (File.Exists("note.ns"))
                {
                    System.IO.FileInfo file1 = new System.IO.FileInfo("note.ns");
                    if (DateTime.Compare(CurrentGroup.Notes[CurrentUser.Id].EditedAt, file1.LastWriteTime) > 0)
                    {
                        CurrentGroup.Notes[CurrentUser.Id].Text = File.ReadAllText("note.ns");
                    }
                }

                _groups[_currentGroup.MulticastAddress] = CurrentGroup;
            }

            
            Services.Repository.Save( this );
        }

        public static NSContext Load( NSContextServices services )
        {
            NSContext c = services.Repository.LoadUnitializedContext();
            c.Initialize( services );
            return c;
        }

        public void Receiver()
        {
            Services.Lan.InitializeReceiver();
        }
        public void Sender()
        {
            if (CurrentGroup != null)
            {

                if (File.Exists("note.ns"))
                {
                    System.IO.FileInfo file1 = new System.IO.FileInfo("note.ns");
                    if (DateTime.Compare(CurrentGroup.Notes[CurrentUser.Id].EditedAt, file1.LastWriteTime) > 0)
                    {
                        CurrentGroup.Notes[CurrentUser.Id].Text = File.ReadAllText("note.ns");
                    }
                }

                Helper.dd(CurrentGroup.Name + " was send");
                Services.Lan.InitializeSender( CurrentGroup.ToTransportable(), 
                    CurrentGroup.ToTransportable(true));
            }
        }
        public void JoinGroup( string mca )
        {
            if (_currentMca != mca)
            {
                _currentMca = mca;
                Services.Lan.JoinGroup(mca);
            }
        }
        public void LeaveGroup( string mca )
        {
            Services.Lan.LeaveGroup( mca );
        }
        public Object ReceivedData()
        {
            return Services.Lan.DefaultGroupData();
        }
        public Object GroupData()
        {
            return Services.Lan.GroupData();
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
