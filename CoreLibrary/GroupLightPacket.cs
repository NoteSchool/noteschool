using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    [Serializable]
    public class GroupLightPacket
    {
        public string Name;
        public string Tag;
        public string MulticastAddress;
        readonly public string user;

        public GroupLightPacket(Group group, string userid)
        {
            user = userid;
            Name = group.Name;
            Tag = group.Tag;
            MulticastAddress = group.MulticastAddress;
        }
    }
}
