using MessageReceiver.Interface;
using MessageReceiver.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver.Configure
{
    public class Startup
    {
        public static IServiceProvider ConfigureSerivce()
        {
            var provider = new ServiceCollection()
                   .AddTransient<IRabbitConnection, RabbitConnection>()
                   .AddTransient<IReceiver, Receiver>()
                   .BuildServiceProvider();

            return provider;
        }
    }
}
