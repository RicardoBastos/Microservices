﻿using System;
using System.Threading.Tasks;
using Core.RabbitMq.Events;
using Seguranca.Domain.Events;

namespace Seguranca.Domain.Subscribes
{
    public class NovoUsuarioEventHandler: IEventHandler<UsuarioNovoEvent>, IDisposable
    {
        public Task Handle(UsuarioNovoEvent message)
        {
            Console.WriteLine(message.Serialize());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
  }