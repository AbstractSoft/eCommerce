namespace eCommerce.Domain.Support.Contracts.Entities
{
    using FluentValidation;

    public abstract class Entity : eCommerce.Domain.Support.Contracts.Validators.IValidateable
    {
        protected Entity()
            : this(System.Guid.NewGuid())
        {
        }

        protected Entity(System.Guid objectId)
        {
            ObjectId = objectId;
        }

        protected abstract IValidator GetValidator();

        public System.Guid ObjectId { get; }

        public virtual void ValidateAndThrow()
        {
            var validationResult = GetValidator()
                .Validate(new ValidationContext<object>(this));

            if (validationResult?.IsValid == false)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}