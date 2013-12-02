using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public interface ILocalAreaNetwork
    {
        string InitializeReceiver();
        void JoinGroup(string mca ="224.0.1.0");
        void LeaveGroup( string mca = "224.0.1.0" );
        void InitializeSender(string sendingData);
    }
}
