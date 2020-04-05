using System;
using System.Threading.Tasks;
using Core.Domain.Bus;
using Core.RabbitMq.Events;
using Seguranca.Domain.Usuario.Commands;
using Seguranca.Domain.Usuario.Events;

namespace Seguranca.Domain.Usuario.Subscribes
{
    public class NovoUsuarioEventHandler: IEventHandler<UsuarioNovoEvent>, IDisposable
    {
        private readonly IMediatorHandler Bus;

        public NovoUsuarioEventHandler(IMediatorHandler bus)
        {
            this.Bus = bus ?? throw new ArgumentNullException(nameof(IMediatorHandler));
        }


        public Task Handle(UsuarioNovoEvent message)
        {
            //Console.WriteLine(message.Serialize());
            var cmd = new UsuarioNovoCommand();
            cmd.Id = new Guid(message.Id);
            cmd.Nome = message.Nome;
            cmd.Email = message.Email;

            Bus.EnviarCommand(cmd);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
  }
