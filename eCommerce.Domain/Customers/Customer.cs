namespace eCommerce.Domain.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public sealed class Customer : eCommerce.Domain.Support.Contracts.Entities.Entity,
        eCommerce.Domain.Support.Contracts.Entities.IAggregateRoot
    {
        private Customer(Guid objectId)
            : base(objectId)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;

            CreditCards = new List<CreditCard>();
            Addresses = new List<eCommerce.Domain.Countries.Address>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }

        public List<CreditCard> CreditCards { get; }
        public List<eCommerce.Domain.Countries.Address> Addresses { get; }

        public void ChangeEmail(string email)
        {
            if (Email == email)
            {
                return;
            }

            Email = email;

            eCommerce.Domain.Support.Events.DomainEvents.Raise(
                new eCommerce.Domain.Customers.Events.CustomerChangedEmail
                {
                    Customer = this
                });
        }

        public static Customer Create(string firstname, string lastname, string email)
        {
            return Create(Guid.NewGuid(), firstname, lastname, email);
        }

        public static Customer Create(Guid id, string firstname, string lastname, string email)
        {
            Customer customer = new(id)
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };

            customer.ValidateAndThrow();

            eCommerce.Domain.Support.Events.DomainEvents
                .Raise(new eCommerce.Domain.Customers.Events.CustomerCreated()
                {
                    Customer = customer
                });

            return customer;
        }

        public ReadOnlyCollection<CreditCard> GetAvailableCreditCards()
        {
            return CreditCards
                .FindAll(new eCommerce.Domain.Customers.Specifications.CreditCardAvailableSpec(DateTime.Today)
                    .IsSatisfiedBy).AsReadOnly();
        }

        public void AddCard(string nameOnCard, string cardNumber, DateTime expiry)
        {
            var creditCard = CreditCard.Create(this, nameOnCard, cardNumber, expiry);

            CreditCards.Add(creditCard);

            eCommerce.Domain.Support.Events.DomainEvents
                .Raise(new eCommerce.Domain.Customers.Events.CreditCardAdded
                {
                    CreditCard = creditCard
                });
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            return new eCommerce.Domain.Customers.Validators.CustomerValidator();
        }
    }
}