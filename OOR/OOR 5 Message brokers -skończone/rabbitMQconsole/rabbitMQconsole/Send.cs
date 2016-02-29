using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbitMQconsole
{
    class Send
    {
        public static void Main()
        {
            while (true)
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    Console.WriteLine("Wpisz treść wiadomości! ");
                    string text = Console.ReadLine();
                    var body = Encoding.UTF8.GetBytes(text);

                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                    Console.WriteLine("Wysłano wiadomość o treści: "+ text);
                }
            }
        }
    }
}
