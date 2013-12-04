using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    class Note : NSObject
    {
        internal Note( NSContext c, Group group)
            : base( c )
        {
            Debug.Assert( Context == c );
            Debug.Assert( group != null );
        }
    }
}
