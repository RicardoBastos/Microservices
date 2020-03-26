using Core.Domain.Bus;
using Core.Domain.Notifications;
using Core.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Usuario.Commands;

namespace RH.Api.Controllers
{
    [Route("[controller]")]
    public class UsuariosController : ApiController
    {
        private readonly IMediatorHandler Bus;


        public UsuariosController(IRabbitMQEventBus eventBus,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus):base(notifications,bus)
        {
            Bus = bus;
       
        }


        [HttpPost]
        [Route("Novo")]
        public IActionResult Post([FromBody]UsuarioNovoCommand usuario)
        {
            Bus.EnviarCommand(usuario);
            return Response(usuario);
        }
    }
}