using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Protocols.TestSuites.Rdp
{
    public class QueueMessage
    {
        public string MessageType; //START_RDP_CONNECTION or CLOSE_RDP_CONNECTION

        public string HelpMessage;

        public string CaseName;

        public string LocalAddress;

        public string RDPPort;

        public bool IsDirectApproach;

        public bool IsFullScreen;
    }
}
