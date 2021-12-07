namespace eCommerce.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using eCommerce.Domain.Customers;
    using Microsoft.AspNetCore.Authorization;
    using eCommerce.Application.Commands.Customer;
    using System.Threading.Tasks;

    [Authorize]
    public class CustomersController : ApiControllerBase
    {
        private readonly MediatR.IMediator mediator;

        public CustomersController(MediatR.IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Customer customer)
        {
            await mediator.Send(new CreateCustomerCommand(customer));
            
            return Ok();
        }
    }
}