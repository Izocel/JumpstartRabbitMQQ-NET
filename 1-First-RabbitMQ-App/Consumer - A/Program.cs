using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

using Entities;
using System.Threading.Tasks;

var random = new Random();

var factory = new ConnectionFactory() { HostName = "localhost", Password = "@rabbitmqroot2022", UserName = "root" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.ExchangeDeclare(exchange: "topic", type: ExchangeType.Topic);


//temporary queue
var queueName = channel.QueueDeclare().QueueName;
channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
channel.QueueBind(queue: queueName, exchange: "topic", routingKey: "*.europe.*");

var consumer = new EventingBasicConsumer(channel);

var message = "{}";
var messageReceived = false;

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    message = Encoding.UTF8.GetString(body);
    messageReceived = true;

    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
};

while (true)
{
    var processTime = random.Next(1, 6);
    channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
   
    if (messageReceived)
    {
        Console.WriteLine($"ConsumerA => Recieved new message: {message} will take: {processTime}s. to process");
        Task.Delay(TimeSpan.FromSeconds(processTime)).Wait();

        var forecast = JsonSerializer.Deserialize<WeatherForecast>(message);
        Console.WriteLine(forecast.Summary);
        messageReceived = false;
    }
}
