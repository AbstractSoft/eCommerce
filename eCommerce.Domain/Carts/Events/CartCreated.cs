namespace eCommerce.Domain.Carts.Events
{
    public class CartCreated : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public eCommerce.Domain.Carts.Cart Cart { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Cart.Customer.ObjectId);
            Args.Add("CartId", Cart.ObjectId);
        }
    }
}
