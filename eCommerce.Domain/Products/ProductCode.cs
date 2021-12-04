namespace eCommerce.Domain.Products
{
    using System;

    public class ProductCode: eCommerce.Domain.Support.Contracts.ValueObjects.ValueObject
    {
        private ProductCode(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static ProductCode Create(string name)
        {
            ProductCode productCode = new(name);

            eCommerce.Domain.Support.Events.DomainEvents.Raise(new ProductCodeCreated()
            {
                ProductCode = productCode
            });
            
            productCode.ValidateAndThrow();

            return productCode;
        }

        protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
    }
}
