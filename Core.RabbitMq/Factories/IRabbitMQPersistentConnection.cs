using RabbitMQ.Client;
using Core.RabbitMq.Configurations;
using System;

namespace Core.RabbitMq.Factories
{
    public interface IRabbitMQPersistentConnection : IDisposable
    {
        RabbitMQEventBusConnectionConfiguration Configuration { get; }
        string Endpoint { get; }
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
