namespace eCommerce.Domain.Customers.Specifications
{
    using System;
    using System.Linq.Expressions;

    public class CreditCardAvailableSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<CreditCard>
    {
        readonly DateTime dateTime;

        public CreditCardAvailableSpec(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public override Expression<Func<CreditCard, bool>> SpecExpression
        {
            get
            {
                return creditCard => creditCard.Active && creditCard.Expiry >= dateTime;
            }
        }
    }
}
