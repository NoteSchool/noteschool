using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class NSContextServices
    {
        readonly IRepository _repo;
       // readonly ILocalAreaNetwork _lan;

        public NSContextServices( IRepository repo) //ILocalAreaNetwork lan)
        {    
            if (repo == null)
                throw new ArgumentNullException("repo");
            _repo = repo;
           // _lan = lan;
        }
        
        public IRepository Repository
        {
            get { return _repo; }
        }
       /*
        public ILocalAreaNetwork Lan
        {
            get { return _lan; }
        }
        * */
    }
}
