using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.DependencyInjection;
using MessageReceiver.Service;
using MessageReceiver.Configure;
using MessageReceiver.Interface;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        var container = Startup.ConfigureSerivce();
        var _ReceiveService = container.GetService<IReceiver>();

        var message = _ReceiveService.ReceiveEvent();
        if (!message.Equals(""))
        {
            Console.WriteLine(" *** Waiting for messages from queue..");
            Console.WriteLine("Received the following message: {0}", message);

        }
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();

    }
    }
