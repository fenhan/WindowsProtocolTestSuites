using Microsoft.Protocols.TestTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Protocols.TestSuites.Rdp
{
    public class QueueBasedRdpSUTControlAdapter : ManagedAdapterBase, IRdpSutControlAdapter
    {
        const string interfaceFullName = "Microsoft.Protocols.TestSuites.Rdp.IRdpSutControlAdapter";

        private QueueHandler queueHandler;
        private string localAddress;
        private string rdpPort;

        public override void Initialize(ITestSite testSite)
        {
            base.Initialize(testSite);

            this.queueHandler = new QueueHandler(testSite);
            this.localAddress = testSite.Properties["SUTControl.LocalAddress"];
            this.rdpPort = testSite.Properties["RDP.ServerPort"];           

        }


        public int CaptureScreenShot(string caseName, string filePath)
        {
            throw new NotImplementedException();
        }

        public int RDPConnectWithDirectCredSSP(string caseName)
        {
            string helpMessage = CommonUtility.GetHelpMessage(interfaceFullName);
            return StartRDPConnection(caseName, helpMessage, true, false);
        }

        public int RDPConnectWithDirectCredSSPFullScreen(string caseName)
        {
            string helpMessage = CommonUtility.GetHelpMessage(interfaceFullName);
            return StartRDPConnection(caseName, helpMessage, true, true);
        }

        public int RDPConnectWithNegotiationApproach(string caseName)
        {
            string helpMessage = CommonUtility.GetHelpMessage(interfaceFullName);
            return StartRDPConnection(caseName, helpMessage, false, false);
        }

        public int RDPConnectWithNegotiationApproachFullScreen(string caseName)
        {
            string helpMessage = CommonUtility.GetHelpMessage(interfaceFullName);
            return StartRDPConnection(caseName, helpMessage, false, true);
        }

        public int TriggerClientAutoReconnect(string caseName)
        {
            throw new NotImplementedException();
        }

        public int TriggerClientDisconnect(string caseName)
        {
            throw new NotImplementedException();
        }

        public int TriggerClientDisconnectAll(string caseName)
        {
            string helpMessage = CommonUtility.GetHelpMessage(interfaceFullName);

            QueueMessage message = new QueueMessage()
            {
                MessageType = "CLOSE_RDP_CONNECTION",
                HelpMessage = helpMessage,
                CaseName = caseName,
                LocalAddress = this.localAddress,
                RDPPort = this.rdpPort,
                IsDirectApproach = false,
                IsFullScreen = false
            };

            queueHandler.InsertMessage(message);
            WaitForResponse();
            return 1;
        }

        public int TriggerInputEvents(string caseName)
        {
            throw new NotImplementedException();
        }

        private void WaitForResponse()
        {
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 3));
        }

        private int StartRDPConnection(string caseName, string helpMessage, bool isDirectApproach, bool isFullScreen)
        {
            QueueMessage message = new QueueMessage()
            {
                MessageType = "START_RDP_CONNECTION",
                HelpMessage = helpMessage,
                CaseName = caseName,
                LocalAddress = this.localAddress,
                RDPPort = this.rdpPort,
                IsDirectApproach = isDirectApproach,
                IsFullScreen = isFullScreen
            };

            queueHandler.InsertMessage(message);
            WaitForResponse();

            return 1;
        }
    }
}
