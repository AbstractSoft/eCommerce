namespace eCommerce.Domain.Purchases
{
    using System;
    using System.Linq.Expressions;

    public class CustomerPurchasesSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Purchase>
    {
        readonly Guid customerId;

        public CustomerPurchasesSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get
            {
                return purchase => purchase.Customer.ObjectId == customerId;
            }
        }
    }
}
