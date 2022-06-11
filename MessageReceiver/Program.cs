using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    VirtualHost = "/",
                    UserName = "guest",
                    Password = "guest"
                };

                using (var conn = factory.CreateConnection())
                {
                    using (var channel = conn.CreateModel())
                    {
                        channel.QueueDeclare("Department_1", true,false,false,null);
                        Console.WriteLine(" [*] Waiting for messages from queue..");

                        var consumer = new EventingBasicConsumer(channel);
                        channel.BasicConsume("Department_1", true, consumer);

                        consumer.Received += (model, get) =>
                         {
                             var rawMessage = get.Body.ToArray();
                             var encodedMessage = Encoding.UTF8.GetString(rawMessage);
                             Console.WriteLine("Received the following message: {0}", encodedMessage);

                         };
                       
                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                    }
                }
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
