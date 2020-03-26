using Core.Domain.Events;
using RH.Infra.Repository.EventSourcing;
using System.Text.Json;


namespace RH.Infra.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
            //_user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonSerializer.Serialize(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "admin");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}