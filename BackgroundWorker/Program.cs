using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using BackgroundWoker;
using Microsoft.EntityFrameworkCore;
using Models;
using BackgroundWorker;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

var appDbOptions = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(@"server=.\SQLDEVELOPER;database=HashDB;Integrated Security=true").Options;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "hash",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var consumer = new EventingBasicConsumer(channel);

HashService service = new();
 
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    List<Hash>? hashes = JsonConvert.DeserializeObject<List<Hash>>(message);
    await service.Save(appDbOptions, hashes);
    Console.WriteLine($"Recieved new message");
};



channel.BasicConsume(queue: "hash", autoAck: true, consumer: consumer);
Console.ReadKey();