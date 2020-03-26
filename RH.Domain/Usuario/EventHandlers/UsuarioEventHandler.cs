using Core.RabbitMq;
using MediatR;
using RH.Domain.Usuario.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RH.Domain.Usuario.EventHandlers
{
    public class UsuarioEventHandler :
       INotificationHandler<UsuarioNovoEvent>
    {
        private readonly IRabbitMQEventBus _eventBus;

        public UsuarioEventHandler(IRabbitMQEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task Handle(UsuarioNovoEvent message, CancellationToken cancellationToken)
        {
            _eventBus.Publish(message, exchange: "Empresa.RHEvent", routingKey: "empresa.rhevent.novousuario");
            return Task.CompletedTask;
        }

    }
}
