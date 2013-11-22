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

        internal Group( NSContext c, string name, string tag, string multicastAddress)
            : base( c )
        {
            Debug.Assert( Context == c );
            Debug.Assert( !String.IsNullOrWhiteSpace( name ) );
            Debug.Assert( c.FindGroup( name ) == null );

            _name = name;
            _tag = tag;
            _multicastAddress = multicastAddress;
        }
        /*
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
<<<<<<< HEAD
        public string Tag
        {
            get { return _tag; }
        }
=======
        */
        public string Name { get { return _name; } }
        public string Tag { get { return _tag; } }
        public string MulticastAddress { get { return _multicastAddress; } }
    }
}
