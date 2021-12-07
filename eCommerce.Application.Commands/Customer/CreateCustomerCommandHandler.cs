namespace eCommerce.Application.Commands.Customer
{
    using System.Threading.Tasks;
    using System.Threading;
    using eCommerce.Application.Commands.Contracts;

    public class CreateCustomerCommandHandler : MediatR.IRequestHandler<CreateCustomerCommand, MediatR.Unit>
    {
        private readonly ICustomerRepository customerRepository;

        // Inject here any other required dependencies like logging and so on
        // If there are many dependencies required to be injected, consider to use a Facade
        // or, better, to redesign the code
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository) 
        {
            this.customerRepository = customerRepository;
        }

        public async Task<MediatR.Unit> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            await customerRepository.AddCustomerAsync(request.Customer)
                .ConfigureAwait(false);

            return MediatR.Unit.Value; // Mediatr version of Void
        }
    }
}