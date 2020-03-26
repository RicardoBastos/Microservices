using System;
using System.Text.Json.Serialization;
using Core.Domain.Events;
using FluentValidation.Results;

namespace Core.Domain
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
                    
        public abstract bool IsValid();
    }
}