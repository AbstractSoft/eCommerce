namespace eCommerce.Domain.Carts.Specifications
{
    using System;
    using System.Linq.Expressions;

    public class CustomerCartSpec : 
        eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<eCommerce.Domain.Carts.Cart>
    {
        readonly Guid customerId;

        public CustomerCartSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<eCommerce.Domain.Carts.Cart, bool>> SpecExpression
        {
            get
            {
                return cart => cart.Customer.ObjectId == customerId;
            }
        }
    }
}
