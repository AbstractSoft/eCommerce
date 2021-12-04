namespace eCommerce.Domain.Customers.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CustomerBulkIdFindSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Customer>
    {
        readonly IEnumerable<Guid> customerIds;

        public CustomerBulkIdFindSpec(IEnumerable<Guid> customerIds)
        {
            this.customerIds = customerIds;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customerIds.Contains(customer.ObjectId);
            }
        }
    }
}
