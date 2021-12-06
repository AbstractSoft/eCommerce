namespace eCommerce.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Microsoft.AspNetCore.Authorization.AuthorizeAttribute]
    public class CustomersController : ApiControllerBase
    {
        private readonly MediatR.IMediator mediator;

        public CustomersController(MediatR.IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<MediatR.Unit> Create(
            eCommerce.Application.Commands.Customer.CreateCustomerCommand command)
        {
            return await mediator.Send(command);
        }
    }
}