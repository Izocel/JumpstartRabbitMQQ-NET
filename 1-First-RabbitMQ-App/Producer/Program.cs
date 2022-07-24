using System;
using System.Text;
using RabbitMQ.Client;
using Entities;
using System.Threading.Tasks;

var random = new Random();

var factory = new ConnectionFactory() { HostName = "localhost", Password = "@rabbitmqroot2022", UserName = "root" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.ExchangeDeclare(exchange: "topic", type: ExchangeType.Topic);


var messageId = 1;
var forecast = new WeatherForecast();

while(true)
{
    forecast.Id = messageId;
    var forecastJson = forecast.ToSerialized();
    var body = Encoding.UTF8.GetBytes(forecastJson);

    var publishingTime = random.Next(1, 4);
    Task.Delay(TimeSpan.FromSeconds(publishingTime)).Wait();

    channel.BasicPublish(exchange: "topic", routingKey: "user.europe.payments", null, body);
    Console.WriteLine($"Send message: id:{messageId} value:{forecastJson}");
    messageId++;
}

