namespace eCommerce.Domain.Carts.Specifications
{
    using System;
    using System.Linq.Expressions;

    public class ProductInCartSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<CartProduct>
    {
        readonly eCommerce.Domain.Products.Product product;

        public ProductInCartSpec(eCommerce.Domain.Products.Product product)
        {
            this.product = product;
        }

        public override Expression<Func<CartProduct, bool>> SpecExpression
        {
            get
            {
                return cartProduct => cartProduct.ProductId == product.ObjectId;
            }
        }
    }
}
