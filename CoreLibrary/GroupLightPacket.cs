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

        public GroupLightPacket(Group group)
        {
            Name = group.Name;
            Tag = group.Tag;
            MulticastAddress = group.MulticastAddress;
        }
    }
}
