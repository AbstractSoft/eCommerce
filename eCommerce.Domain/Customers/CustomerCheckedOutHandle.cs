namespace eCommerce.Domain.Customers
{
    public class CustomerCheckedOutHandle : 
        eCommerce.Domain.Support.Events.Contracts.IHandle<eCommerce.Domain.Customers.Events.CustomerCheckedOut>
    {
        private readonly eCommerce.Domain.Email.Contracts.IEmailDispatcher emailDispatcher;
        private readonly eCommerce.Domain.Email.Contracts.IEmailGenerator emailGenerator;

        public CustomerCheckedOutHandle(
            eCommerce.Domain.Email.Contracts.IEmailGenerator emailGenerator, 
            eCommerce.Domain.Email.Contracts.IEmailDispatcher emailSender)
        {
            emailDispatcher = emailSender;
            this.emailGenerator = emailGenerator;
        }

        public void Handle(eCommerce.Domain.Customers.Events.CustomerCheckedOut args)
        {
            args.Flatten();
            
            emailDispatcher.Dispatch(
                emailGenerator.Generate(args.Args["CustomerId"], eCommerce.Domain.Email.EmailTemplate.PurchaseMade)
                );

            //send notifications, update third party systems, etc
        }
    }
}
