using System;
using System.Collections.Generic;
using System.Text;

namespace SaltpayBank.Seedwork
{
    public abstract class BaseEntity
    {
        private List<IDomainEvent> _events;
        public IReadOnlyList<IDomainEvent> Events => _events.AsReadOnly();

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        protected void RemoveEvent(IDomainEvent @event)
        {
            _events.Remove(@event);
        }
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; set; }
    }
}
