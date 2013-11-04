using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class User
    {
        private string _name;
        private string _firstName;
        private long _id;
        private DateTime _registerDate;

        // pour aurel : refactoriser les setter

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                // Database.SetUserField(_id, "name", _name );
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
               // Database.SetUserField(_id, "firstName", _firstName );
            }
        }

        public long Id
        {
            get { return _id; }
        }

        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set
            {
                _registerDate = value;
                // Database.SetUserField(_id, "registerDate", _registerDate );
            }
        }

        public User( string name, string firstName )
        {
            RegisterDate = DateTime.Now;
            Name = name;
            FirstName = firstName;

            DateTime dtDateTime = new DateTime( 1970, 1, 1, 0, 0, 0, 0 );
            _id = dtDateTime.Ticks;

            // database.insertUser(this);
        }
    }
}
