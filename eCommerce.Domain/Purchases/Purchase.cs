namespace eCommerce.Domain.Purchases
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Purchase : eCommerce.Domain.Support.Contracts.Entities.Entity
    {
        private List<PurchasedProduct> purchasedProducts = new List<PurchasedProduct>();

        public ReadOnlyCollection<PurchasedProduct> Products
        {
            get { return purchasedProducts.AsReadOnly(); }
        }

        public DateTime Created { get; protected set; }
        public eCommerce.Domain.Customers.Customer Customer { get; protected set; }
        public decimal TotalTax { get; protected set; }
        public decimal TotalCost { get; protected set; }

        public static Purchase Create(eCommerce.Domain.Carts.Cart cart)
        {
            var purchase = new Purchase()
            {
                Created = DateTime.Today,
                Customer = cart.Customer,
                TotalCost = cart.TotalCost,
                TotalTax = cart.TotalTax
            };

            var purchasedProducts = new List<PurchasedProduct>();
            foreach (eCommerce.Domain.Carts.CartProduct cartProduct in cart.Products)
            {
                purchasedProducts.Add(PurchasedProduct.Create(purchase, cartProduct));
            }

            purchase.purchasedProducts = purchasedProducts;

            return purchase;
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
    }
}