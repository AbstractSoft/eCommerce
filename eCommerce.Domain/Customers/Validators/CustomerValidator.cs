namespace eCommerce.Domain.Customers.Validators
{
    using FluentValidation;

    public class CustomerValidator : FluentValidation.AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();
            
            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}