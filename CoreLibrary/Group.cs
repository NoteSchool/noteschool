using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteSchool
{
    public class Group
    {

        public string Hash;
        private Database DB;

        private string _title;
        private string _date;
        public String Title
        {
            set { if (Hash != null) { DB.SetGroupField(Hash, "Title", value); } _title = value; }
            get { return _title; }
        }

        public String Date { set; get; }

        public Group(String title, String date)
        {
            DB = new Database();

            Title = title;
            Date = date;

            DB.AddGroup(this);
        }

        public Group(String hash)
        {
            DB = new Database();
            Hash = hash;

            DB.GetGroupByHash(hash, this);
        }

        /* public static bool exists(String hash) {
             return Database.isGroupExists(hash);
         }*/
    }
}
