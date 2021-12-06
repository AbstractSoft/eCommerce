namespace eCommerce.DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;

    [ExcludeFromCodeCoverage]
    [Table("CreditCard")]
    public class CreditCard
    {
        [Key] public int Id { get; set; }

        public System.Guid AggregateId { get; set; }

        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public bool Active { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Expiry { get; set; }
        public Customer Customer { get; set; }
    }
}