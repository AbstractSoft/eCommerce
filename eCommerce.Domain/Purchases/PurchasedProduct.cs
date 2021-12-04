namespace eCommerce.Domain.Purchases
{
    using System;

    public class PurchasedProduct
    {
        public Guid PurchaseId { get; protected set; }
        public Guid ProductId { get; protected set; }
        public int Quantity { get; protected set; }

        public static PurchasedProduct Create(Purchase purchase, eCommerce.Domain.Carts.CartProduct cartProduct)
        {
            return new PurchasedProduct()
            {
                ProductId = cartProduct.ProductId,
                PurchaseId = purchase.ObjectId,
                Quantity = cartProduct.Quantity
            };
        }
    }
}
