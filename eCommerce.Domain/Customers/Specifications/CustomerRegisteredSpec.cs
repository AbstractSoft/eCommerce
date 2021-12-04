namespace eCommerce.Domain.Customers.Specifications
{
    using System;
    using System.Linq.Expressions;

    public class CustomerRegisteredSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Customer>
    {
        Guid id;

        public CustomerRegisteredSpec(Guid id)
        {
            this.id = id;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customer.ObjectId == id;
            }
        }
    }
}
