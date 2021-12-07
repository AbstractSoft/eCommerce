namespace eCommerce.DataAccess.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    public interface IDataContext
    {
        public void AddCustomer(eCommerce.DataAccess.Entities.Customer customer);
        
        int SaveChanges();
    }
}
