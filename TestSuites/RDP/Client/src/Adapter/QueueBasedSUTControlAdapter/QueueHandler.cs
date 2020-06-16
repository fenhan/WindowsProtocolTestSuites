using Azure.Storage.Queues;
using Microsoft.Protocols.TestTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Protocols.TestSuites.Rdp
{
    public class QueueHandler
    {
        private ITestSite Site;

        private readonly string storageConnectionString;

        private readonly string queueName;

        private readonly QueueClient queueClient;

        public QueueHandler(ITestSite testSite)
        {
            this.Site = testSite;
            this.storageConnectionString = testSite.Properties["SUTControl.StorageConnectionString"];
            this.queueName = testSite.Properties["SUTControl.QueueName"];

            this.queueClient = new QueueClient(storageConnectionString, queueName);

            // Create the queue
            queueClient.CreateIfNotExists();
        }

        public void InsertMessage(QueueMessage message)
        {
            var messageString = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            queueClient.SendMessage(messageString);
        }


    }
}
