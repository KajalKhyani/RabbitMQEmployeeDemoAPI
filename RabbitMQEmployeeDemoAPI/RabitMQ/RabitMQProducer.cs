﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQEmployeeDemoAPI.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendEmployeeMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            using
                var channel = connection.CreateModel();
            channel.QueueDeclare("employee", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "employee", body: body);
        }
    }
}
