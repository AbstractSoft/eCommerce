namespace eCommerce.Domain.Purchases
{
    using System;
    using System.Linq.Expressions;
    
    public class PurchasedNProductsSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Purchase>
    {
        readonly int nProducts;

        public PurchasedNProductsSpec(int nProducts)
        {
            this.nProducts = nProducts;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get
            {
                return purchase => purchase.Products.Count >= nProducts;
            }
        }
    }
}
