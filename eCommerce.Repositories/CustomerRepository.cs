namespace eCommerce.Persistence
{
    using eCommerce.Persistence.Contracts;
    using eCommerce.DataAccess.Contracts;
    using CommandsContracts = eCommerce.Application.Commands.Contracts;
    using QueriesContracts = eCommerce.Application.Queries.Contracts;
    using System.Threading.Tasks;
    using eCommerce.Domain.Customers;

    public class CustomerRepository : BaseRepository, CommandsContracts.ICustomerRepository, QueriesContracts.ICustomerRepository
    {
        private readonly IDataContext dataContext;

        public CustomerRepository(IDataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            // Perform a mapping to the entities specific to the DB
            // Fill data context with data
            // save the changes
            throw new System.NotImplementedException();
        }

        public async Task<System.Collections.Generic.IReadOnlyList<Customer>> GetAllCustomersAsync()
        {
           //return await dataContext.GetAllCustomersAsync();
           throw new System.NotImplementedException();
        }
    }
}