namespace eCommerce.Persistence.Contracts
{
    public abstract class BaseRepository 
    {
        protected BaseRepository(eCommerce.DataAccess.Contracts.IDataContext context)
        {
            DataContext = context;
        }

        public eCommerce.DataAccess.Contracts.IDataContext DataContext { get; }
    }
}