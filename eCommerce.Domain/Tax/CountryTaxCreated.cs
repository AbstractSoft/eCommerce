namespace eCommerce.Domain.Tax
{
    public class CountryTaxCreated : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public CountryTax CountryTax { get; set; }

        public override void Flatten()
        {
            Args.Add("CountryTaxId", CountryTax.Id);
            Args.Add("CountryTaxCountryId", CountryTax.Country.Id);
            Args.Add("CountryTaxPercentage", CountryTax.Percentage);
            Args.Add("CountryTaxType", CountryTax.Type);
        }
    }
}
