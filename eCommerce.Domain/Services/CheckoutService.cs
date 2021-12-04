namespace eCommerce.Domain.Services
{
    using System;

    public class CheckoutService : eCommerce.Domain.Support.Contracts.Services.IDomainService
    {
        public PaymentStatus CustomerCanPay(eCommerce.Domain.Customers.Customer customer)
        {
            if (customer.Balance < 0)
                return PaymentStatus.UnpaidBalance;

            if (customer.GetCreditCardsAvailble().Count == 0)
                return PaymentStatus.NoActiveCreditCardAvailable;

            return PaymentStatus.OK;
        }

        public ProductState ProductCanBePurchased(eCommerce.Domain.Carts.Cart cart)
        {
            eCommerce.Domain.Support.Specification.Contracts.ISpecification<eCommerce.Domain.Products.Product> faultyProductSpec = new eCommerce.Domain.Products.ProductReturnReasonSpec(eCommerce.Domain.Products.ReturnReason.Faulty);

            foreach (var cartProduct in cart.Products)
            {
                eCommerce.Domain.Products.Product product = this.productRepository.FindById(cartProduct.ProductId);
                if (product == null)
                    throw new Exception($"Product {cartProduct.ProductId} not found");

                var isInStock = new eCommerce.Domain.Products.ProductIsInStockSpec(cartProduct).IsSatisfiedBy(product);

                if (!isInStock)
                    return ProductState.NotInStock;

                var isFaulty = faultyProductSpec.IsSatisfiedBy(product);

                if (isFaulty)
                    return ProductState.IsFaulty;
            }
            return ProductState.OK;
        }

        public Nullable<eCommerce.Domain.Carts.CheckOutIssue> CanCheckOut(eCommerce.Domain.Customers.Customer customer, eCommerce.Domain.Carts.Cart cart)
        {
            var paymentStatus = CustomerCanPay(customer);
            if (paymentStatus != PaymentStatus.OK)
                return (eCommerce.Domain.Carts.CheckOutIssue)paymentStatus;

            var productState = ProductCanBePurchased(cart);
            if (productState != ProductState.OK)
                return (eCommerce.Domain.Carts.CheckOutIssue)productState;

            return null;
        }

        public eCommerce.Domain.Purchases.Purchase Checkout(eCommerce.Domain.Customers.Customer customer, eCommerce.Domain.Carts.Cart cart)
        {
            var checkoutIssue = CanCheckOut(customer, cart);
            if (checkoutIssue.HasValue)
                throw new Exception(checkoutIssue.Value.ToString());

            var purchase = eCommerce.Domain.Purchases.Purchase.Create(cart);

            this.purchaseRepository.Add(purchase);

            cart.Clear();

            eCommerce.Domain.Support.Events.DomainEvents.Raise<eCommerce.Domain.Customers.Events.CustomerCheckedOut>(new eCommerce.Domain.Customers.Events.CustomerCheckedOut() { Purchase = purchase });

            return purchase;
        }

    }
}
