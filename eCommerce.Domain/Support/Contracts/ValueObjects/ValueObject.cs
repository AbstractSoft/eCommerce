namespace eCommerce.Domain.Support.Contracts.ValueObjects
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;

    // Source: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects

    public abstract class ValueObject : eCommerce.Domain.Support.Contracts.Validators.IValidateable
    {
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                // If either value (but not both) is null, return false
                if (thisValues.Current is null ^ otherValues.Current is null)
                {
                    return false;
                }

                // If both values are null, move to next
                if (thisValues.Current is null)
                {
                    continue;
                }

                // If both values are index-able, check for sequential equality
                if (thisValues.Current is IList thisList && otherValues.Current is IList otherList)
                {
                    var thisGenList = thisList.Cast<object>();
                    var otherGenList = otherList.Cast<object>();
                    if (!thisGenList.SequenceEqual(otherGenList))
                    {
                        return false;
                    }
                }
                // If both values are enumerable but not index-able, check for collection equality
                else if (thisValues.Current is IEnumerable thisCollection && otherValues.Current is IEnumerable otherCollection)
                {
                    var thisGenCollection = thisCollection.Cast<object>().ToList();
                    var otherGenCollection = otherCollection.Cast<object>().ToList();
                    // If the collections contain different amounts of elements or collection B does not contain all of collection A's elements, return false
                    if (thisGenCollection.Count != otherGenCollection.Count
                        || !thisGenCollection.All(thisElement =>
                            otherGenCollection.Any(otherElement =>
                                Equals(thisElement, otherElement))))
                    {
                        return false;
                    }
                }
                else if (!thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Aggregate(92821, (result, obj) =>
            {
                // https://github.com/dotnet/roslyn/blob/master/src/Compilers/Test/Resources/Core/NetFX/ValueTuple/ValueTuple.cs#L11
                var rol5 = ((uint)result << 5) | ((uint)result >> 27);
                return ((int)rol5 + result) ^ obj?.GetHashCode() ?? 0;
            });
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        protected abstract IValidator GetValidator();

        public virtual void ValidateAndThrow()
        {
            var validationResult = GetValidator()
                .Validate(new ValidationContext<object>(this));

            if (validationResult?.IsValid == false)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public T Copy<T>() where T : ValueObject
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<T, T>()
                .ConstructUsing(x => System.Activator.CreateInstance<T>()));
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            return mapper.Map<T, T>((T)this);
        }
    }
}
