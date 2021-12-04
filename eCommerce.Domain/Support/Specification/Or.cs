namespace eCommerce.Domain.Support.Specification
{
    using System;
    using System.Linq.Expressions;

    public class Or<T> : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<T>
    {
        private readonly eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> left;
        private readonly eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> right;

        public Or(eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> left, eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        // OrSpecification
        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(
                        Expression.Invoke(left.SpecExpression, objParam),
                        Expression.Invoke(right.SpecExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}
