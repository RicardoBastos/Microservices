using Core.Domain.Bus;
using Core.Domain.Events;
using Core.Domain.Notifications;
using Core.Infra.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seguranca.Domain.Usuario.CommandHandlers;
using Seguranca.Domain.Usuario.Commands;
using Seguranca.Domain.Usuario.Events;
using Seguranca.Domain.Usuario.Interface;
using Seguranca.Domain.Usuario.Interfaces;
using Seguranca.Infra.Context;
using Seguranca.Infra.EventSourcing;
using Seguranca.Infra.Repository;
using Seguranca.Infra.Repository.Dapper;
using Seguranca.Infra.Repository.EventSourcing;

namespace Seguranca.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<UsuarioNovoCommand, bool>, UsuarioCommandHandler>();


            // Infra - Data
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioDapperRepository, UsuarioDapperRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SegurancaContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
