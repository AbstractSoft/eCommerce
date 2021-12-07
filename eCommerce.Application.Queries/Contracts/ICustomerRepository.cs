namespace eCommerce.Application.Queries.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using eCommerce.Domain.Customers;

    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetAllCustomersAsync();
    }
}