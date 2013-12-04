﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class User: NSObject
    {
        private string _lastName;
        private string _firstName;
        private string _id;
        
        internal User(NSContext c, string firstName, string lastName)
            :base (c)
        {
            _firstName = firstName;
            _lastName = lastName;
            _id = Guid.NewGuid().ToString("N"); ;
        }

        public string LastName { get { return _lastName; } }
        public string FirstName { get { return _firstName; } }
        public string Id { get { return _id; } }
    }
}
