using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DB = NoteSchool.Database;

namespace NoteSchool
{
    public class Group
    {
        private string _title;
        private DateTime _date;
        private string _hash; //md5 ID of the Group

        public string Hash { get { return _hash; } }

        public DateTime Date { get { return _date; } }

        public String Title
        {
            set 
            { 
                if (_hash != null) 
                    DB.SetGroupField(_hash, "Title", value); 
                _title = value; 
            }
            get { return _title; }
        }

        #region constructors
        public Group(String title, DateTime date)
        {
            _title = title;
            _date = date;
            
            SetHash();

            DB.AddGroup(this);
        }

        public Group(String hash)
        {
            Open(hash);
        }
        #endregion constructors

        private void SetHash()
        {          
            _hash = Helper.GetMd5Hash(_title + _date.ToString());
        }

        public bool Open(string hash)
        {
            _hash = hash;

            return DB.GetGroupByHash(_hash, this);
        }
    }
}
