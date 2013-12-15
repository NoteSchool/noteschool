using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public interface ILocalAreaNetwork
    {
        void InitializeReceiver();
        void InitializeSender(Object obj);
        void JoinGroup(string mca);
        void LeaveGroup( string mca);
        //Object GroupData();
        Object DefaultGroupData();
    }
}
