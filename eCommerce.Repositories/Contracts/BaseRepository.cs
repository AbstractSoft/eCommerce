namespace eCommerce.Persistence.Contracts
{
    using eCommerce.DataAccess.Contracts;
    public abstract class BaseRepository 
    {
        protected BaseRepository(IDataContext context)
        {
            DataContext = context;
        }

        public IDataContext DataContext { get; }
    }
}