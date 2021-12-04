namespace eCommerce.Domain.Products
{
    public class ProductCodeCreated : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public ProductCode ProductCode { get; set; }

        public override void Flatten()
        {
            Args.Add("ProductCodeName", ProductCode.Name);
        }
    }
}
