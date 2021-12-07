namespace eCommerce.Application.Commands.Customer
{
    using eCommerce.Domain.Customers;

    public record CreateCustomerCommand(Customer Customer) : MediatR.IRequest;
}