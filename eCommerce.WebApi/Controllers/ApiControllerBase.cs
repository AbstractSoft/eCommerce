namespace eCommerce.WebApi.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender mediator = null!;

        protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}