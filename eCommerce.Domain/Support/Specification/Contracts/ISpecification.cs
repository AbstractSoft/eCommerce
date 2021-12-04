namespace eCommerce.Domain.Support.Specification.Contracts
{
    using System;
    using System.Linq.Expressions;

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}
