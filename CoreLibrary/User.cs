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
        private string _id;
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

        public string Id
        {
            get { return _id; }
            set { _id = value; }
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
            _id = Guid.NewGuid().ToString("N");

            // database.insertUser(this);
        }
    }
}
