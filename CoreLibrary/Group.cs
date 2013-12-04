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
        Dictionary<String, Note> _notes;

        internal Group( NSContext c, string name, string tag, string multicastAddress)
            : base( c )
        {
            Debug.Assert( Context == c );
            Debug.Assert( !String.IsNullOrWhiteSpace( name ) );
            Debug.Assert( c.FindGroup( name ) == null );

            _name = name;
            _tag = tag;
            _multicastAddress = multicastAddress;

            _notes = new Dictionary<String, Note>();
            //default note
            FindOrCreateNote();
        }
        public string Name { get { return _name; } }
        public string Tag { get { return _tag; } }
        public string MulticastAddress { get { return _multicastAddress; } }


        public Note FindOrCreateNote()
        {
            Note n;
            if (!_notes.TryGetValue(Context.CurrentUser.Id, out n))
            {
                n = new Note();
                _notes.Add(Context.CurrentUser.Id, n);
            }

            return n;
        }
    }
}
