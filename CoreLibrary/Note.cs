using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class Note
    {
        private string _text;
        private DateTime _editedAt;

        private int _rate;
        private List<String> _ratersId;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public DateTime EditedAt { get { return _editedAt; } }
        public int Rate { get { return _rate; }}
        public List<String> RatersId { get { return _ratersId; }}

        internal Note()
        {
            _editedAt = DateTime.Now;
            _rate = 0;
            _ratersId = new List<string>();
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
