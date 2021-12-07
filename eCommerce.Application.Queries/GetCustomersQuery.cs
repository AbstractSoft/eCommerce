namespace eCommerce.Application.Queries
{
    using System.Collections.Generic;
    using eCommerce.Domain.Customers;
    
    public record GetCustomersQuery : MediatR.IRequest<IReadOnlyList<Customer>>;
}