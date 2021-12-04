namespace eCommerce.Domain.Email.Contracts
{
    using System.Net.Mail;

    public interface IEmailDispatcher
    {
        void Dispatch(MailMessage mailMessage);
    }
}
