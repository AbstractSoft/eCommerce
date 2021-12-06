namespace eCommerce.Application.Commands.Customer
{
    public class CreateCustomerCommandHandler : MediatR.IRequestHandler<CreateCustomerCommand>
    {
        public System.Threading.Tasks.Task<MediatR.Unit> Handle(CreateCustomerCommand request, System.Threading.CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}