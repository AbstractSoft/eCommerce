namespace eCommerce.Domain.Customers.Events
{
    public class CustomerCheckedOut : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public eCommerce.Domain.Purchases.Purchase Purchase { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Purchase.Customer.ObjectId);
            Args.Add("PurchaseId", Purchase.ObjectId);
            Args.Add("TotalCost", Purchase.TotalCost);
            Args.Add("TotalTax", Purchase.TotalTax);
            Args.Add("NumberOfProducts", Purchase.Products.Count);
        }
    }
}
