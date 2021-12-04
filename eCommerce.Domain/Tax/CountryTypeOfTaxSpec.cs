namespace eCommerce.Domain.Tax
{
    using System;
    using System.Linq.Expressions;

    public class CountryTypeOfTaxSpec : eCommerce.Domain.Support.Specification.Contracts.SpecificationBase<CountryTax>
    {
        readonly Guid countryId;
        readonly TaxType taxType;

        public CountryTypeOfTaxSpec(Guid countryId, TaxType taxType)
        {
            this.countryId = countryId;
            this.taxType = taxType;
        }

        public override Expression<Func<CountryTax, bool>> SpecExpression
        {
            get
            {
                return countryTax => countryTax.Country.ObjectId == countryId
                    && countryTax.Type == taxType;
            }
        }

        public override bool Equals(object obj)
        {
            var countryTypeOfTaxSpecCompare = obj as CountryTypeOfTaxSpec;
            
            if (countryTypeOfTaxSpecCompare == null)
            {
                throw new InvalidCastException("obj");
            }

            return countryTypeOfTaxSpecCompare.countryId == countryId &&
                countryTypeOfTaxSpecCompare.taxType == taxType;
        }
    }
}
