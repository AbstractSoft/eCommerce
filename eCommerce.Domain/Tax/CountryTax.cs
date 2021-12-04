namespace eCommerce.Domain.Tax
{
    using System;

    public class CountryTax :
        eCommerce.Domain.Support.Contracts.Entities.Entity,
        eCommerce.Domain.Support.Contracts.Entities.IAggregateRoot
    {
        private CountryTax(Guid objectId)
            : base(objectId)
        {
            Country = country;
            Percentage = percentage;
            Type = type;
        }

        public virtual eCommerce.Domain.Countries.Country Country { get; set; }
        public virtual decimal Percentage { get; set; }
        public virtual TaxType Type { get; set; }

        public static CountryTax Create(TaxType type, eCommerce.Domain.Countries.Country country, decimal percentage)
        {
            return Create(Guid.NewGuid(), type, country, percentage);
        }

        public static CountryTax Create(Guid id, TaxType type, eCommerce.Domain.Countries.Country country,
            decimal percentage)
        {
            var countryTax = new CountryTax(id)
            {
                Country = country,
                Percentage = percentage,
                Type = type
            };

            eCommerce.Domain.Support.Events.DomainEvents.Raise<CountryTaxCreated>(new CountryTaxCreated()
                { CountryTax = countryTax });

            return countryTax;
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
    }
}