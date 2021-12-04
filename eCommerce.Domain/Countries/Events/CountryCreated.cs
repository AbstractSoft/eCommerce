namespace eCommerce.Domain.Countries.Events
{
    public class CountryCreated : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public Country Country { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Id", Country.ObjectId);
            this.Args.Add("Name", Country.Name);
        }
    }
}
