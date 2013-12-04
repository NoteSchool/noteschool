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
        private DateTime _date;
        private Group _group;
        private string _text;
        private string _id;

        private int _rate;
        private List<String> _ratersId;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public DateTime Date { get { return _date; } }
        public Group Group { get { return _group; } }
        public int Rate { get { return _rate; }}
        public List<String> RatersId { get { return _ratersId; }}
        public string Id { get { return _id; } }

        internal Note(NSContext c, Group group)
            :base(c)
        {
            _date = DateTime.Now;
            _group = group;
            _rate = 0;
            _ratersId = new List<string>();
            _id = Guid.NewGuid().ToString("N");
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
