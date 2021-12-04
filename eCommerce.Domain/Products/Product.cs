namespace eCommerce.Domain.Products
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public sealed class Product : eCommerce.Domain.Support.Contracts.Entities.Entity, 
        eCommerce.Domain.Support.Contracts.Entities.IAggregateRoot
    {
        private readonly List<Return> returns = new();

        private Product(Guid id)
            : base(id)
        {
            Name = String.Empty;
            Code = ProductCode.Create(string.Empty);
        }

        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public ProductCode Code { get; set; }
        public ReadOnlyCollection<Return> Returns => returns.AsReadOnly();

        public static Product Create(string name, int quantity, decimal cost, ProductCode productCode)
        {
            return Create(Guid.NewGuid(), name, quantity, cost, productCode);
        }

        public static Product Create(Guid id, string name, int quantity, decimal cost, ProductCode productCode)
        {
            var product = new Product(id)
            {
                Name = name,
                Quantity = quantity,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Active = true,
                Cost = cost,
                Code = productCode
            };

            eCommerce.Domain.Support.Events.DomainEvents.Raise(new ProductCreated()
            {
                Product = product
            });

            return product;
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
    }
}