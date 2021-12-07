namespace eCommerce.Domain.Countries
{
    public abstract class Address : eCommerce.Domain.Support.Contracts.ValueObjects.ValueObject
    {
        protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new System.NotImplementedException();
        }
    }
}