using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver.ReceiveEventService
{
    public class ReceiverConnection
    {
        public ConnectionFactory RabbitmqConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest"
            };
            return factory;
        }
    }
}
