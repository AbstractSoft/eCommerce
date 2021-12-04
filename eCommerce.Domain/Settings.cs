namespace eCommerce.Domain
{
    public class Settings
    {
        public virtual eCommerce.Domain.Countries.Country BusinessCountry { get; protected set; }

        public Settings()
        {
            
        }

        public Settings(eCommerce.Domain.Countries.Country businessCountry)
        {
            BusinessCountry = businessCountry;
        }
    }
}
