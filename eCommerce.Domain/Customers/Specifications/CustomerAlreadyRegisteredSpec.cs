namespace eCommerce.Domain.Customers.Specifications
{
    using System;
    using System.Linq.Expressions;

    public class CustomerAlreadyRegisteredSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Customer>
    {
        string email;

        public CustomerAlreadyRegisteredSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customer.Email == email;
            }
        }
    }
}
