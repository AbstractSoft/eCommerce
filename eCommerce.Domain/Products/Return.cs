namespace eCommerce.Domain.Products
{
    using System;

    public class Return
    {
        public virtual Product Product { get; protected set; }
        public virtual eCommerce.Domain.Customers.Customer Customer { get; protected set; }
        public virtual ReturnReason Reason { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual string Note { get; protected set; }
    }
}
