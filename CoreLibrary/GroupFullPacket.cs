using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class GroupFullPacket
    {
        public string Name;
        public string Tag;
        public string MulticastAddress;
        public Dictionary<String, Note> Notes;
        public Dictionary<String, User> Users; 

        public GroupFullPacket(Group group)
        {
            Name = group.Name;
            Tag = group.Tag;
            MulticastAddress = group.MulticastAddress;
            Notes = group.Notes;
            Users = group.Users;
        }
    }
}
