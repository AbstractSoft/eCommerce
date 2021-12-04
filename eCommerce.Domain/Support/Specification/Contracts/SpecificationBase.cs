namespace eCommerce.Domain.Support.Specification.Contracts
{
    using System;
    using System.Linq.Expressions;

    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        private Func<T, bool> compiledExpression;
 
        private Func<T, bool> CompiledExpression
        {
            get { return compiledExpression ??= SpecExpression.Compile(); }
        }
 
        public abstract Expression<Func<T, bool>> SpecExpression { get; }

        public bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}
