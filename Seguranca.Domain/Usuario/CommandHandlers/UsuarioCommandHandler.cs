using Core.Domain.Bus;
using Core.Domain.Notifications;
using Core.Infra.Interface;
using Core.RabbitMq;
using MediatR;
using Seguranca.Domain.Usuario.Commands;
using Seguranca.Domain.Usuario.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seguranca.Domain.Usuario.CommandHandlers
{
    public class UsuarioCommandHandler : CommandHandler,
       IRequestHandler<UsuarioNovoCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler Bus;
        private readonly IRabbitMQEventBus _eventBus;

        public UsuarioCommandHandler(IRabbitMQEventBus eventBus,
                                      IUsuarioRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _usuarioRepository = customerRepository;
            Bus = bus;
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task<bool> Handle(UsuarioNovoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var usuario = new Usuario(message.Id, message.Nome, message.Email);

            if (_usuarioRepository.BuscarEmail(usuario.Email) != null)
            {
                Bus.EnviarEvent(new DomainNotification(message.MessageType, "E-mail já existe"));
                return Task.FromResult(false);
            }

            _usuarioRepository.Add(usuario);

            Commit();

            return Task.FromResult(true);
        }


        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }


}
