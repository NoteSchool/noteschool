using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class Note : NSObject
    {
        readonly DateTime _date;
        readonly Group _group;
        string _text;

        int _rate;
        List<String> _ratersId;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        internal Note(NSContext c, Group group)
            :base(c)
        {
            _date = DateTime.Now;
            _group = group;
            _rate = 0;
        }

        /// <summary>
        /// Ajoute un like à la note
        /// </summary>
        /// <param name="userid"></param>
        public void RateIt(string userid)
        {
            _rate++;
            _ratersId.Add(userid);
        }
    }
}
