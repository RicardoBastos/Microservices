using System;

namespace Core.Domain.Interface
{
    public interface IEntity<TKey>
         where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
