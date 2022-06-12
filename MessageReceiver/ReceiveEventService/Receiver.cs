using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageReceiver.ReceiveEventService
{
    public class Receiver
    {
        public string ReceiveEvent()
        {
           
            ReceiverConnection conn = new ReceiverConnection();
            var factory = conn.RabbitmqConnection();
            var encodedMessage = "";

            try
            {
             
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("Department_1", true, false, false, null);

                        var consumer = new EventingBasicConsumer(channel);
                        channel.BasicConsume("Department_1", true, consumer);

                        consumer.Received += (model, get) =>
                        {
                            var rawMessage = get.Body.ToArray();
                             encodedMessage = Encoding.UTF8.GetString(rawMessage);
                        };
                       
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return encodedMessage;
        }
    }
}