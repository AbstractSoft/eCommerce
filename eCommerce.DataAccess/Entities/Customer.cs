namespace eCommerce.DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;

    [ExcludeFromCodeCoverage]
    [Table("Customer")]
    public class Customer
    {
        public Customer()
        {
            CreditCards = new System.Collections.Generic.HashSet<CreditCard>();
            Addresses = new System.Collections.Generic.HashSet<Address>();
        }

        [Key] 
        public System.Guid ObjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public System.Collections.Generic.ICollection<CreditCard> CreditCards { get; set; }
        public System.Collections.Generic.ICollection<Address> Addresses { get; set; }
    }
}