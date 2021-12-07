namespace eCommerce.Application.Queries
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;
    using eCommerce.Domain.Customers;
    using eCommerce.Application.Queries.Contracts;

    public class GetCustomersQueryHandler : MediatR.IRequestHandler<GetCustomersQuery, IReadOnlyList<Customer>>
    {
        private readonly ICustomerRepository customerRepository;

        // Inject here any other required dependencies like logging and so on
        // If there are many dependencies required to be injected, consider to use a Facade
        // or, better, to redesign the code
        public GetCustomersQueryHandler(eCommerce.Application.Queries.Contracts.ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<IReadOnlyList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetAllCustomersAsync()
                .ConfigureAwait(false);
        }
    }
}