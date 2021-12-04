namespace eCommerce.Domain.Support.Events.Contracts
{
    public interface IHandle<T> 
        where T : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        void Handle(T args); 
    } 
}
