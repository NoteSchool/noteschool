using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
   /// <summary>
    /// classe dont heritera tous nos objets.
   /// </summary>
    [Serializable]
    public abstract class NSObject
    {
        protected NSContext _context;

        protected NSObject(NSContext c)
        {
            if (c == null) throw new ArgumentNullException("c");
            _context = c;
        }

        public NSContext Context { get { return _context; } }

    }
}
