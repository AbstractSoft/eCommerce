namespace eCommerce.Domain.Countries
{
    using System;

    public class Country : eCommerce.Domain.Support.Contracts.Entities.Entity
    {
        private Country(Guid id)
            : base(id)
        {
            Name = string.Empty;
        }

        public string Name { get; set; }

        public static Country Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static Country Create(Guid id, string name)
        {
            var country = new Country(id)
            {
                Name = name
            };

            eCommerce.Domain.Support.Events.DomainEvents.Raise(new eCommerce.Domain.Countries.Events.CountryCreated()
            {
                Country = country
            });

            return country;
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
    }
}