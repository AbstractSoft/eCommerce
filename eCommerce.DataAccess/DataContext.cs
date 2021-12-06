namespace eCommerce.DataAccess
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using eCommerce.DataAccess.Entities;

    [ExcludeFromCodeCoverage]
    public class DataContext : 
        Microsoft.EntityFrameworkCore.DbContext,
        eCommerce.DataAccess.Contracts.IDataContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder options) => 
            options.UseSqlServer("connection string");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>()
                .HasOne<Customer>(creditCard=>creditCard.Customer)
                .WithMany(customer=>customer.CreditCards)
                .HasForeignKey(creditCard=>creditCard.AggregateId);
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public void AddCustomer(eCommerce.DataAccess.Entities.Customer customer)
        {
            Customers.Add(customer);
            SaveChanges();
        }
    }
}
