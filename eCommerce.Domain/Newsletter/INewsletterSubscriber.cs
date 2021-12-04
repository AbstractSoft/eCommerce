namespace eCommerce.Domain.Newsletter
{
    public interface INewsletterSubscriber
    {
        void Subscribe(eCommerce.Domain.Customers.Customer customer);
    }
}
