namespace eCommerce.Domain.Customers.Events
{
    public class CustomerCheckedOut : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public Purchase Purchase { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Purchase.CustomerId);
            Args.Add("PurchaseId", Purchase.Id);
            Args.Add("TotalCost", Purchase.TotalCost);
            Args.Add("TotalTax", Purchase.TotalTax);
            Args.Add("NumberOfProducts", Purchase.Products.Count);
        }
    }
}
