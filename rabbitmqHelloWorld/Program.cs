using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { 
    HostName = "192.168.0.116",
    UserName = "yetir",
    Password = "asdf1234"  ,
    Port = 5672,
    VirtualHost = "/"
};
 

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Yetir.DistributionFinalize",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = "Hello World!";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: "Yetir.DistributionFinalize",
                         basicProperties: null,
                         body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();