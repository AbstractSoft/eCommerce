namespace eCommerce.Domain.Support.Specification
{
    public static class Extensions
    {
        public static eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> And<T>(
            this eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> left, eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> right)
        {
            return new And<T>(left, right);
        }

        public static eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> Or<T>(
            this eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> left, eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> right)
        {
            return new Or<T>(left, right);
        }

        public static eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> Negate<T>(this eCommerce.Domain.Support.Specification.Contracts.ISpecification<T> inner)
        {
            return new Negated<T>(inner);
        }
    }
}
