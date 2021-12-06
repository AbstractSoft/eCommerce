namespace eCommerce.Persistence
{
    public class CustomerRepository : eCommerce.Persistence.Contracts.BaseRepository
    {
        public CustomerRepository(eCommerce.DataAccess.Contracts.IDataContext context)
            : base(context)
        {
        }
    }
}