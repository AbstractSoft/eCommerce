namespace eCommerce.Domain.Support.Specification
{
    using System;
    using System.Linq.Expressions;

    public class Negated<T> : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<T>
    {
        private readonly eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> _inner;

        public Negated(eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> inner)
        {
            _inner = inner;
        }

        // NegatedSpecification
        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.Not(
                        Expression.Invoke(_inner.SpecExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}
