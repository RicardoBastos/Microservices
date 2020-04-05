using Core.Domain;
using Core.Domain.Bus;
using Core.Domain.Notifications;
using Core.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seguranca.Domain.Usuario.Interface;
using System;
using System.Threading.Tasks;

namespace Seguranca.Api.Controllers
{
    [Route("seguranca/[controller]")]
    public class UsuariosController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly IUsuarioDapperRepository _usuarioDapperRepository;


        public UsuariosController(IRabbitMQEventBus eventBus,
             IUsuarioDapperRepository usuarioDapperRepository,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus):base(notifications,bus)
        {
            Bus = bus;
            _usuarioDapperRepository = usuarioDapperRepository ?? throw new ArgumentNullException(nameof(IUsuarioDapperRepository));


        }

        [HttpGet, Route("")]
        public async Task<Result> Get([FromQuery]string nome, [FromQuery]Paging paginacao)
        {
            var objRetorno = TratarQuery(await _usuarioDapperRepository.GetPaging(nome, paginacao));
            return objRetorno;
        }

    }
}