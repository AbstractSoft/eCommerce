namespace eCommerce.Domain.Support.Events.Contracts
{
    using System;
    using System.Collections.Generic;

    public abstract class DomainEvent 
    {
        public string Type => GetType().Name;

        public DateTime Created { get; }

        public Dictionary<string, Object> Args { get; }

        public string CorrelationId { get;  set; }

        public DomainEvent()
        {
            Created = DateTime.Now;
            Args = new Dictionary<string, object>();
        }

        public abstract void Flatten();
    }
}
