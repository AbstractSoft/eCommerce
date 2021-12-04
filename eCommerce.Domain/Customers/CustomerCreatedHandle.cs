namespace eCommerce.Domain.Customers
{
    public class CustomerCreatedHandle :
        eCommerce.Domain.Support.Events.Contracts.IHandle<eCommerce.Domain.Customers.Events.CustomerCreated>
    {
        readonly eCommerce.Domain.Newsletter.INewsletterSubscriber newsletterSubscriber;
        readonly eCommerce.Domain.Email.Contracts.IEmailDispatcher emailDispatcher;

        public CustomerCreatedHandle(eCommerce.Domain.Newsletter.INewsletterSubscriber newsletterSubscriber, 
            eCommerce.Domain.Email.Contracts.IEmailDispatcher emailDispatcher)
        {
            this.newsletterSubscriber = newsletterSubscriber;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(eCommerce.Domain.Customers.Events.CustomerCreated args)
        {
            //example #1 calling an interface email dispatcher this can have different kind of implementation depending on context, e.g
            // smtp = SmtpEmailDispatcher, exchange = ExchangeEmailDispatcher, msmq = MsmqEmailDispatcher, etc...
            emailDispatcher.Dispatch(new System.Net.Mail.MailMessage());

            //example #2 calling an interface newsletter subscriber  this can different kind of implementation e.g
            // web service = WSNewsletterSubscriber (current), msmq = MsmqNewsletterSubscriber, Sql = SqlNewsletterSubscriber, etc...
            newsletterSubscriber.Subscribe(args.Customer);
        }
    }
}