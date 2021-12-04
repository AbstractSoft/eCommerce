namespace eCommerce.Domain.Customers.Events
{
    public class CustomerCreated : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            Args.Add("FirstName", Customer.FirstName);
            Args.Add("LastName", Customer.LastName);
            Args.Add("Email", Customer.Email);
        }
    }
}
