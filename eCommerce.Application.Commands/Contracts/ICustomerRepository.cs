namespace eCommerce.Application.Commands.Contracts
{
    using  System.Threading.Tasks;
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(eCommerce.Domain.Customers.Customer customer);
    }
}