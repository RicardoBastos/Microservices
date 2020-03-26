using Core.Domain.Bus;
using Core.Domain.Notifications;
using Core.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Seguranca.Api.Controllers
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

    }
}