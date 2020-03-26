using Core.Domain.Bus;
using Core.Domain.Events;
using Core.Domain.Notifications;
using Core.Infra.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RH.Domain.Usuario.CommandHandlers;
using RH.Domain.Usuario.Commands;
using RH.Domain.Usuario.EventHandlers;
using RH.Domain.Usuario.Events;
using RH.Domain.Usuario.Interfaces;
using RH.Infra.Context;
using RH.Infra.EventSourcing;
using RH.Infra.Repository;
using RH.Infra.Repository.EventSourcing;

namespace RH.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UsuarioNovoEvent>, UsuarioEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<UsuarioNovoCommand, bool>, UsuarioCommandHandler>();


            // Infra - Data
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<RHContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
