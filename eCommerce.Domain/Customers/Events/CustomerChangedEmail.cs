namespace eCommerce.Domain.Customers.Events
{
    public class CustomerChangedEmail : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Customer.ObjectId);
            Args.Add("Email", Customer.Email);
        }
    }
}
