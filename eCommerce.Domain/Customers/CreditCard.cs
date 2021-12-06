namespace eCommerce.Domain.Customers
{
    public class CreditCard : eCommerce.Domain.Support.Contracts.ValueObjects.ValueObject
    {
        public string NameOnCard { get; private init; }
        public string CardNumber { get; private init; }
        public bool Active { get; private init; }
        public System.DateTime Created { get; private init; }
        public System.DateTime Expiry { get; private init; }
        public Customer Customer { get; private init; }

        public static CreditCard Create(Customer customer, string name, string cardNum, System.DateTime expiry)
        {
            if (customer == null)
                throw new System.Exception("Customer object can't be null");

            if (string.IsNullOrEmpty(name))
                throw new System.Exception("Name can't be empty");

            if (string.IsNullOrEmpty(cardNum) || cardNum.Length < 6)
                throw new System.Exception("Card number length is incorrect");

            if (System.DateTime.Now > expiry)
                throw new System.Exception("Credit card expiry can't be in the past");

            var creditCard = new CreditCard
            {
                Customer = customer,
                NameOnCard = name,
                CardNumber = cardNum,
                Expiry = expiry,
                Active = true,
                Created = System.DateTime.Today
            };

            if (customer.CreditCards.Contains(creditCard))
            {
                throw new System.Exception("Can't add same card to the collection");
            }

            return creditCard;
        }

        public override bool Equals(object obj)
        {
            var creditCardToCompare = obj as CreditCard;
            if (creditCardToCompare == null)
            {
                throw new System.Exception("Can't compare two different objects to each other");
            }

            return CardNumber == creditCardToCompare.CardNumber &&
                   Expiry == creditCardToCompare.Expiry;
        }

        protected override System.Collections.Generic.IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }

        protected override FluentValidation.IValidator GetValidator()
        {
            throw new System.NotImplementedException();
        }
    }
}