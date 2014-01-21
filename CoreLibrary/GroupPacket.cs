using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class GroupPacket
    {
        public string Name;
        public string Tag;
        public string MulticastAddress;

        public GroupPacket(Group group)
        {
            Name = group.Name;
            Tag = group.Tag;
            MulticastAddress = group.MulticastAddress;
        }
    }
}
