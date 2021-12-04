namespace eCommerce.Domain.Products
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductReturnReasonSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Product>
    {
        readonly ReturnReason returnReason;

        public ProductReturnReasonSpec(ReturnReason returnReason)
        {
            this.returnReason = returnReason;
        }

        public override Expression<Func<Product, bool>> SpecExpression
        {
            get
            {
                return product => product.Returns.ToList().Exists(returns => returns.Reason == returnReason);
            }
        }
    }
}
