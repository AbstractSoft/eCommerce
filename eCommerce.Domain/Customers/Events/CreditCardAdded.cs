﻿namespace eCommerce.Domain.Customers.Events
{
    public class CreditCardAdded : eCommerce.Domain.Support.Events.Contracts.DomainEvent
    {
        public CreditCard CreditCard { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", CreditCard.Customer.ObjectId);
            Args.Add("NameOnCard", CreditCard.NameOnCard);
            Args.Add("Last3Digits", CreditCard.CardNumber.Substring(CreditCard.CardNumber.Length - 3, 3));
        }
    }
}
