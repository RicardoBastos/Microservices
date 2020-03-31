using Core.Domain.Bus;
using Core.Domain.Notifications;
using Core.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Usuario.Commands;
using System;

namespace RH.Api.Controllers
{
    [Route("rh/[controller]")]
    public class UsuariosController : ApiController
    {
        private readonly IMediatorHandler Bus;


        public UsuariosController(IRabbitMQEventBus eventBus,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus):base(notifications,bus)
        {
            Bus = bus ?? throw new ArgumentNullException(nameof(IMediatorHandler));

        }


        [HttpPost]
        [Route("Novo")]
        public IActionResult Post([FromBody]UsuarioNovoCommand usuario)
        {
            Bus.EnviarCommand(usuario);
            return Response(usuario);
        }

        [HttpGet, Route("")]
        public ActionResult<string> Get()
        {
            return "Usuarios RH";
        }
    }
}