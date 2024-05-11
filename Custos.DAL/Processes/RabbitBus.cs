﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Custos.DAL.Processes
{
    public class RabbitBus : IBus
    {
        private readonly IModel _channel;
        internal RabbitBus(IModel channel)
        {
            _channel = channel;
        }
        public async Task SendAsync<T>(string queue, T message)
        {
            await Task.Run(() =>
            {
                _channel.QueueDeclare(queue, true, false, false);
                var properties = _channel.CreateBasicProperties();
                properties.Persistent = false;
                if (message.GetType() == typeof(string))
                {
                    var output1 = message.ToString();
                    _channel.BasicPublish(string.Empty, queue, null,
                    Encoding.UTF8.GetBytes(output1));
                }
                else
                {
                    var output = JsonConvert.SerializeObject(message);
                    _channel.BasicPublish(string.Empty, queue, null,
                    Encoding.UTF8.GetBytes(output));
                }
              
            });
        }
        public async Task CreateExchange<T>(string exchangename, T message)
        {
            await Task.Run(() =>
            {
               

                _channel.ExchangeDeclare(exchange: exchangename, type: ExchangeType.Fanout);

                 
                if (message.GetType() == typeof(string))
                {
                    var output1 = message.ToString(); 
                    _channel.BasicPublish(exchange: exchangename,
                                   routingKey: string.Empty,
                                   basicProperties: null,
                                   body: Encoding.UTF8.GetBytes(output1));
                }
                else
                {
                    var output = JsonConvert.SerializeObject(message);
                    _channel.BasicPublish(exchange: exchangename,
                                   routingKey: string.Empty,
                                   basicProperties: null,
                                   body: Encoding.UTF8.GetBytes(output));
                }

            });
        }
        public async Task ReceiveAsync<T>(string queue, Action<string> onMessage)
        {
            _channel.QueueDeclare(queue, true, false, false);
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += async (s, e) =>
            {
                Console.WriteLine("Message Received ");
                byte[] body = e.Body.ToArray(); 
                var message = Encoding.UTF8.GetString(body); 
                
                onMessage(message);
                await Task.Yield();
            };
            _channel.BasicConsume(queue, true, consumer);
            await Task.Yield();
        }
    }
}
