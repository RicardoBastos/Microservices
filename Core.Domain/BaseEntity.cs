using Core.Domain.Interface;
using System;

namespace Core.Domain
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
