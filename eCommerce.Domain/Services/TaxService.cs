namespace eCommerce.Domain.Services
{
    using System;

    public class TaxService : eCommerce.Domain.Support.Contracts.Services.IDomainService
    {
        readonly IRepository<eCommerce.Domain.Tax.CountryTax> countryTax;
        readonly Settings settings;

        public TaxService(Settings settings, IRepository<eCommerce.Domain.Tax.CountryTax> countryTax)
        {
            this.countryTax = countryTax;
            this.settings = settings;
        }

        public decimal Calculate(eCommerce.Domain.Customers.Customer customer, eCommerce.Domain.Products.Product product)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (product == null)
                throw new ArgumentNullException("product");

            eCommerce.Domain.Tax.CountryTax customerCountryTax = countryTax
                .FindOne(new eCommerce.Domain.Tax.CountryTypeOfTaxSpec(customer.Country.ObjectId, eCommerce.Domain.Tax.TaxType.Customer));
            eCommerce.Domain.Tax.CountryTax businessCountryTax = countryTax
                .FindOne(new eCommerce.Domain.Tax.CountryTypeOfTaxSpec(settings.BusinessCountry, eCommerce.Domain.Tax.TaxType.Business));

            return (product.Cost * customerCountryTax.Percentage)
                     + (product.Cost * businessCountryTax.Percentage);
        }
    }
}
