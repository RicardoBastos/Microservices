﻿using Core.Domain.Events;
using System;
using System.Collections.Generic;

namespace RH.Infra.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}