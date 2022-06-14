using MessageReceiver.Interface;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver.Service
{
    public class RabbitConnection : IRabbitConnection
    {
        public IModel RabbitmqConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest"
            };

            var _connection = factory.CreateConnection();
            var _channel = _connection.CreateModel();

            return _channel;
        }

        public BasicGetResult FanoutExchangConsumer()
        {
            var setupconn = RabbitmqConnection();
            setupconn.QueueDeclare("Department_1", true, false, false, null);
            BasicGetResult consumer = setupconn.BasicGet("Department_1", true);

            return consumer;
        }
    }
}
