using AccountingPlusDAL.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace AccountingPlusDAL.Context
{
    public partial class AccountingPlusContext : DbContext
    {
        static AccountingPlusContext()
        {
            Database.SetInitializer<AccountingPlusContext>(null);
        }

        public AccountingPlusContext()
            : base("Name=AccountingPlusConnection")
        {

        }

        public DbSet<ControlAccount> ControlAccounts { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Structure> Structures { get; set; }


        public DbSet<Vendor> Vendors { get; set; }


        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductUnit> Products { get; set; }

        public DbSet<Unit> Unit { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        public DbSet<TempControlAccount> TempControlAccounts { get; set; }

        
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public  void UndoingChangesDbContextLevel()
        {
            foreach (DbEntityEntry entry in this.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:                   
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }  




    }
}
