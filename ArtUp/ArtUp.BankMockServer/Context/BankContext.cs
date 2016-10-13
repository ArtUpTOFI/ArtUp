using ArtUp.BankMockServer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Context
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        static BankContext()
        {
            Database.SetInitializer<BankContext>(new StoreDbInitializer());
        }
        public BankContext(string connectionString) : base(connectionString) { }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BankContext>
    {
        protected override void Seed(BankContext db)
        {
            
        }
    }
}
