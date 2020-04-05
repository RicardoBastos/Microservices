using Core.Domain;
using Core.Domain.Bus;
using Core.Domain.Notifications;
using Core.RabbitMq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Usuario.Commands;
using RH.Infra.Repository.Dapper;
using System;
using System.Threading.Tasks;

namespace RH.Api.Controllers
{
    [Route("rh/[controller]")]
    public class UsuariosController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly UsuarioDapperRepository _usuarioDapperRepository;

        public UsuariosController(IRabbitMQEventBus eventBus,
            UsuarioDapperRepository usuarioDapperRepository,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus):base(notifications,bus)
        {
            Bus = bus ?? throw new ArgumentNullException(nameof(IMediatorHandler));
            _usuarioDapperRepository = usuarioDapperRepository ?? throw new ArgumentNullException(nameof(UsuarioDapperRepository));
        }


        [HttpPost]
        [Route("Novo")]
        public IActionResult Post([FromBody]UsuarioNovoCommand usuario)
        {
            Bus.EnviarCommand(usuario);
            return Response(usuario);
        }

        [HttpGet, Route("")]
        public async Task<Result> Get([FromQuery]string nome, [FromQuery]Paging paginacao)
        {
            var objRetorno = TratarQuery(await _usuarioDapperRepository.GetPaging(nome, paginacao));
            return objRetorno;
        }
    }
}