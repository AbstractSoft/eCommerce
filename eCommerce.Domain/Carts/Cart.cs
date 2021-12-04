namespace eCommerce.Domain.Carts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Cart : eCommerce.Domain.Support.Contracts.Entities.Entity
    {
        private readonly List<CartProduct> cartProducts = new();

        public virtual ReadOnlyCollection<CartProduct> Products => cartProducts.AsReadOnly();

        public virtual eCommerce.Domain.Customers.Customer Customer { get; protected set; }

        public virtual decimal TotalCost
        {
            get { return Products.Sum(cartProduct => cartProduct.Quantity * cartProduct.Cost); }
        }

        public virtual decimal TotalTax
        {
            get { return Products.Sum(cartProducts => cartProducts.Tax); }
        }

        public static Cart Create(eCommerce.Domain.Customers.Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            var cart = new Cart
            {
                Customer = customer
            };

            eCommerce.Domain.Support.Events.DomainEvents.Raise(new eCommerce.Domain.Carts.Events.CartCreated
            {
                Cart = cart
            });

            return cart;
        }

        public virtual void Add(CartProduct cartProduct)
        {
            if (cartProduct == null)
            {
                throw new ArgumentNullException();
            }

            eCommerce.Domain.Support.Events.DomainEvents.Raise<eCommerce.Domain.Carts.Events.ProductAddedCart>(
                new eCommerce.Domain.Carts.Events.ProductAddedCart() { CartProduct = cartProduct });

            cartProducts.Add(cartProduct);
        }

        public virtual void Remove(eCommerce.Domain.Products.Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            var cartProduct =
                cartProducts.Find(new eCommerce.Domain.Carts.Specifications.ProductInCartSpec(product).IsSatisfiedBy);

            eCommerce.Domain.Support.Events.DomainEvents.Raise<eCommerce.Domain.Carts.Events.ProductRemovedCart>(
                new eCommerce.Domain.Carts.Events.ProductRemovedCart() { CartProduct = cartProduct });

            cartProducts.Remove(cartProduct);
        }

        public virtual void Clear()
        {
            cartProducts.Clear();
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
    }
}