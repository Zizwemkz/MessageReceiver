using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageReceiver.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageReceiver.Service
{
    public class Receiver : IReceiver
    {
       
             private readonly IRabbitConnection _channel;

        public Receiver(IRabbitConnection channel)
        {
            _channel = channel;
        }   

        public string ReceiveEvent()
        {
            var encodedMessage = "";
            try
            { 
                var consumer = _channel.FanoutExchangConsumer();
                if(consumer != null)
                {
                    var rawMessage = consumer.Body.ToArray();
                    encodedMessage = Encoding.UTF8.GetString(rawMessage);
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