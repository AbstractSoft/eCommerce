namespace eCommerce.Domain.Carts.Events
{
    public class ProductAddedCart : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public CartProduct CartProduct { get; set; }

        public override void Flatten()
        {
            this.Args.Add("CartId", CartProduct.ObjectId);
            this.Args.Add("CustomerId", CartProduct.CustomerId);
            this.Args.Add("ProductId", CartProduct.ProductId);
            this.Args.Add("Quantity", CartProduct.Quantity);
        }
    }
}
