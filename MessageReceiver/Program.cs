using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MessageReceiver.ReceiveEventService;


        var consumer = new Receiver();
        var message = consumer.ReceiveEvent();
        Console.WriteLine(" [*] Waiting for messages from queue..");
        Console.WriteLine("Received the following message: {0}", message);


        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
