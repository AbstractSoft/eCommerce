namespace eCommerce.Domain.Products
{
    using System;
    using System.Linq.Expressions;

    public class ProductIsInStockSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<Product>
    {
        private readonly eCommerce.Domain.Carts.CartProduct productCart;

        public ProductIsInStockSpec(eCommerce.Domain.Carts.CartProduct productCart)
        {
            this.productCart = productCart;
        }

        public override Expression<Func<Product, bool>> SpecExpression
        {

            get
            {
                return product => product.ObjectId == productCart.ProductId && product.Active
                    && product.Quantity >= productCart.Quantity;
            }
        }
    }
}
