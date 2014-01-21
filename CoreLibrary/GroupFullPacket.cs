using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class GroupFullPacket : GroupLightPacket
    {
        public Dictionary<String, Note> Notes;
        public Dictionary<String, User> Users; 

        public GroupFullPacket(Group group, string userid)
            :base(group, userid)
        {
            Notes = group.Notes;
            Users = group.Users;
        }
    }
}
