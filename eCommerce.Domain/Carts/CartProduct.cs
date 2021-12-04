namespace eCommerce.Domain.Carts
{
    using System;

    public class CartProduct : eCommerce.Domain.Support.Contracts.ValueObjects.ValueObject
    {
        public eCommerce.Domain.Customers.Customer Customer { get; private init; }
        public Cart Cart { get; private init; }
        public int Quantity { get; private init; }
        public eCommerce.Domain.Products.Product Product { get; private init; }
        public DateTime Created { get; private init; }
        public decimal Cost { get; private init; }
        public decimal Tax { get; private init; }

        public static CartProduct Create(
            eCommerce.Domain.Customers.Customer customer,
            eCommerce.Domain.Carts.Cart cart,
            eCommerce.Domain.Products.Product product,
            int quantity,
            eCommerce.Domain.Services.TaxService taxService)
        {
            if (cart == null)
                throw new ArgumentNullException("cart");

            if (product == null)
                throw new ArgumentNullException("product");

            var cartProduct = new CartProduct()
            {
                Customer = customer,
                Cart = cart,
                Product = product,
                Quantity = quantity,
                Created = DateTime.Now,
                Cost = product.Cost,
                Tax = taxService.Calculate(customer, product)
            };

            return cartProduct;
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