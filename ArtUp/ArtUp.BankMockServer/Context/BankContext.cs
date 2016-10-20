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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BankContext>
    {
        protected override void Seed(BankContext db)
        {
            db.Accounts.Add(new Account { Id = 1, Nubmer = "1111111111113", FaceType = Enums.FaceType.Individual, FirstName = "Eugene", LastName = "Bychkouski", PatronomicName = "Victorovich", Adress = "center of the earth", Money = 100, Type = Enums.AccountType.Saving });
            db.Accounts.Add(new Account { Id = 2, Nubmer = "2221111111113", FaceType = Enums.FaceType.Individual, FirstName = "Zhuk", LastName = "Anton", PatronomicName = "Sashevich", Adress = "center of the earth", Money = 90, Type = Enums.AccountType.Checking });
            db.Cards.Add(new Card { Id = 1, AccountId = 1, BillingAdress = "center of the earth", CreateDate = "7/7/2012", EndDate = "9/20", CVV2 = 123, FirstName = "Yauheni", LastName = "Bychkouski", Number = "1234567890123456" });
            db.SaveChanges();
        }
    }
}
