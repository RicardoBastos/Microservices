using Core.Domain.Events;
using Core.RabbitMq.Attributes;
using System;

namespace RH.Domain.Usuario.Events
{
    [EventBus(Exchange = "Empresa.RHEvent", RoutingKey = "empresa.rhevent.novousuario")]
    public class UsuarioNovoEvent : Event
    {
        public UsuarioNovoEvent(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }


    }
}
