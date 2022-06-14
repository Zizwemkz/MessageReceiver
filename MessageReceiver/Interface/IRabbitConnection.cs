using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver.Interface
{
   public interface IRabbitConnection
    {
        public IModel RabbitmqConnection();
        public BasicGetResult FanoutExchangConsumer();
    }
}
