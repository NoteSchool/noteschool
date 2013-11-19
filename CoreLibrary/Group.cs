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

        internal Group( NSContext c, string name, string tag)
            : base( c )
        {
            _name = name;
            _tag = tag;
            /*
            Debug.Assert(Context == c);
            Debug.Assert(!String.IsNullOrWhiteSpace(name));
            Debug.Assert(c.FindGroupByName( name ) == null);
             * */
        }

        public string Name
        {
            get { return _name; }
        }
        public string Tag
        {
            get { return _tag; }
        }
    }
}
