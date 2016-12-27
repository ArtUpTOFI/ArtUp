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

        //static BankContext()
        //{
        //    Database.SetInitializer<BankContext>(new StoreDbInitializer());
        //}
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
            db.Accounts.Add(new Account { Id = 1, Nubmer = "1111111111113", FaceType = Enums.FaceType.Individual, FirstName = "Eugene", LastName = "Bychkouski", PatronomicName = "Victorovich", Adress = "center of the earth", Money = 5000, Type = Enums.AccountType.Saving });
            db.Accounts.Add(new Account { Id = 2, Nubmer = "2221111111113", FaceType = Enums.FaceType.Individual, FirstName = "Zhuk", LastName = "Anton", PatronomicName = "Sashevich", Adress = "center of the earth", Money = 800, Type = Enums.AccountType.Checking });
            db.Accounts.Add(new Account { Id = 3, Nubmer = "1111111111114", FaceType = Enums.FaceType.Individual, FirstName = "Romanov", LastName = "Anton", PatronomicName = "Sashevich", Adress = "center of the earth", Money = 900, Type = Enums.AccountType.Checking });
            db.Accounts.Add(new Account { Id = 4, Nubmer = "1111111111115", FaceType = Enums.FaceType.Individual, FirstName = "Obuchovsky", LastName = "Eugene", PatronomicName = "Sashevich", Adress = "center of the earth", Money = 1000, Type = Enums.AccountType.Checking });
            db.Accounts.Add(new Account { Id = 5, Nubmer = "9999999999999", FaceType = Enums.FaceType.Individual, FirstName = "Platform", LastName = "ArtUp", PatronomicName = "", Adress = "Minsk", Money = 0, Type = Enums.AccountType.Saving });
            db.Cards.Add(new Card { Id = 1, AccountId = 1, BillingAdress = "center of the earth", CreateDate = "7/7/2012", EndDate = "09/20", CVV2 = 123, FirstName = "Yauheni", LastName = "Bychkouski", Number = "1234567890123456" });
            db.Cards.Add(new Card { Id = 2, AccountId = 2, BillingAdress = "center of the earth", CreateDate = "7/7/2012", EndDate = "09/21", CVV2 = 123, FirstName = "Anton", LastName = "Zhuk", Number = "1111111111111111" });
            db.Cards.Add(new Card { Id = 3, AccountId = 3, BillingAdress = "center of the earth", CreateDate = "7/7/2012", EndDate = "09/22", CVV2 = 123, FirstName = "Anton", LastName = "Romanov", Number = "2222222222222222" });
            db.Cards.Add(new Card { Id = 4, AccountId = 4, BillingAdress = "center of the earth", CreateDate = "7/7/2012", EndDate = "09/23", CVV2 = 123, FirstName = "Eugene", LastName = "Obuchovsky", Number = "3333333333333333" });
            db.SaveChanges();
        }
    }
}
