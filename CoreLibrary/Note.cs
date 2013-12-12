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

        private int _likes;
        private List<String> _likersId;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public DateTime EditedAt { get { return _editedAt; } set { _editedAt = value; } }
        public int Rate { get { return _likes; }}
        public List<String> RatersId { get { return _likersId; }}

        internal Note()
        {
            _editedAt = DateTime.Now;
            _likes = 0;
            _likersId = new List<string>();
        }

        /// <summary>
        /// Ajoute un like à la note
        /// </summary>
        /// <param name="userid"></param>
        public void LikeIt(string userid)
        {
            _likes++;
            _likersId.Add(userid);
        }

        public static Note GetNote(string text)
        {
            var note = new Note();
            note.Text = text;
            return note;
        }
    }
}
