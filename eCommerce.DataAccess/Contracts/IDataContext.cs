namespace eCommerce.DataAccess.Contracts
{
    public interface IDataContext
    {
        public void AddCustomer(eCommerce.DataAccess.Entities.Customer customer);
        
        int SaveChanges();
    }
}
