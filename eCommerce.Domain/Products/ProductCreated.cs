namespace eCommerce.Domain.Products
{
    public class ProductCreated : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public Product Product { get; set; }

        public override void Flatten()
        {
            Args.Add("ProductId", Product.ObjectId);
            Args.Add("ProductName", Product.Name);
            Args.Add("ProductQuantity", Product.Quantity);
            Args.Add("ProductCode", Product.Code.Name);
            Args.Add("ProductCost", Product.Cost);
        }
    }
}
