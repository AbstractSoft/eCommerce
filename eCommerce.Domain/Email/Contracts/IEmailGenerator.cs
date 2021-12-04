namespace eCommerce.Domain.Email.Contracts
{
    using System.Net.Mail;

    public interface IEmailGenerator
    {
        MailMessage Generate(object objHolder, EmailTemplate emailTemplate);
    }
}
