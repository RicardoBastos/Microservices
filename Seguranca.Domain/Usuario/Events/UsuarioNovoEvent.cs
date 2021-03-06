﻿using Core.RabbitMq.Attributes;
using Core.RabbitMq.Events;

namespace Seguranca.Domain.Usuario.Events
{
    [EventBus(Exchange = "Empresa.RHEvent", RoutingKey = "empresa.rhevent.novousuario")]
    public class UsuarioNovoEvent : IEvent
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

    }
}
