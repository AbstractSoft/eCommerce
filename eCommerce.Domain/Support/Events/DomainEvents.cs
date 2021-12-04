namespace eCommerce.Domain.Support.Events
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// http://www.udidahan.com/2009/06/14/domain-events-salvation/
    /// </summary>
    public static class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> actions;

        private static Castle.Windsor.IWindsorContainer Container;

        public static void Init(Castle.Windsor.IWindsorContainer container)
        {
            Container = container;
        }

        //Registers a callback for the given domain event, used for testing only
        public static void Register<T>(Action<T> callback)
            where T : eCommerce.Domain.Support.Events.Contracts.DomainEvent
        {
            actions ??= new List<Delegate>();

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : eCommerce.Domain.Support.Events.Contracts.DomainEvent
        {
            if (Container != null)
            {
                foreach (var handler in Container.ResolveAll<eCommerce.Domain.Support.Events.Contracts.IHandle<T>>())
                {
                    handler.Handle(args);
                }
            }

            if (actions == null)
            {
                return;
            }
            
            foreach (var action in actions)
            {
                if (action is Action<T> actionT)
                {
                    actionT(args);
                }
            }
        }
    }
}