using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CoreLibrary
{
    [Serializable]
    public class Group : NSObject
    {
        string _name;
        string _tag;
        string _multicastAddress;
        DateTime _notesEditedAt;
        Dictionary<String, Note> _notes;
        Dictionary<String, User> _users;

        internal Group( NSContext c, string name, string tag, string multicastAddress)
            : base( c )
        {
            Debug.Assert( Context == c );
            Debug.Assert( !String.IsNullOrWhiteSpace( name ) );
            Debug.Assert( c.FindGroup( name ) == null );

            _name = name;
            _tag = tag;
            _multicastAddress = multicastAddress;
            _notesEditedAt = DateTime.Now;

            _notes = new Dictionary<String, Note>();
            _users = new Dictionary<String, User>();
            //default note

            CreateNote();
        }

        public DateTime NoteEditedAt { get { return _notesEditedAt; } set { _notesEditedAt = value; } }
        public Dictionary<String, Note> Notes { get { return _notes; } set { _notes = value; } }
        public string Name { get { return _name; } }
        public string Tag { get { return _tag; } }
        public string MulticastAddress { get { return _multicastAddress; } }
        public Dictionary<string, User> Users { get { return _users; } set { _users = value; } }

        public void ReInialize(NSContext c)
        {
            _context = c;
        }

        public void CreateNote()
        {
            if (!_notes.ContainsKey(Context.CurrentUser.Id))
                _notes.Add(Context.CurrentUser.Id, new Note());

            if(!_users.ContainsKey(Context.CurrentUser.Id))
                _users.Add(Context.CurrentUser.Id, Context.CurrentUser);
        }

        public GroupFullPacket ToTransportable()
        {
            return new CoreLibrary.GroupFullPacket(this, _context.CurrentUser.Id);
        }

        public GroupLightPacket ToTransportable(bool full)
        {
            return new CoreLibrary.GroupLightPacket(this, _context.CurrentUser.Id);
        }
    }
}
