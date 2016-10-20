using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Common;
using ArtUp.BankMockServer;
using ArtUp.BankMockServer.Services.Concrete;

namespace BankMockServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = InstanseCreator<TestClass>.GetInstance("ottakot");

            var z = a as TestClass;

            Console.WriteLine(a.ToString());
            Console.WriteLine(z.TestString);

            var inst = InstanseCreator<UserApiService>.GetInstance();
            var service = inst as UserApiService;

            //var uof = new UnitOfWork("BankContext");

            //Console.WriteLine(uof.Accounts.GetAll().First().ToString());

            var list = service.GetAllAccounts();

            foreach (var s in list)
                Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            //Transfer from account 1 to account 2

            var result = service.CreateTransaction("2221111111113", "1111111111113", 20); 
            Console.WriteLine(result.Item1.ToString() + result.Item2);
            var list2 = service.GetAllAccounts();

            foreach (var s in list)
                Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            //_____________________________________

            //Transfer from card  to account 

            var result1 = service.CreateTransaction("1234567890123456", "2221111111113", 123, "9/20", "Yauheni", "Bychkouski", 5);
            Console.WriteLine(result1.Item1.ToString() + result1.Item2);

            var list3 = service.GetAllAccounts();

            foreach (var s in list)
                Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            //_____________________________________

            //Transfer from card  to account (false)

            var result2 = service.CreateTransaction("2224567890123456", "2221111111113", 123, "20", "Yauheni", "Bychkouski", 5);
            Console.WriteLine(result2.Item1.ToString() + result2.Item2);

            var list4 = service.GetAllAccounts();

            foreach (var s in list)
                Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            //_____________________________________

            Console.ReadLine();
        }
    }

    public class TestClass
    {
        public string TestString { get; set; }

        public TestClass(string s)
        {
            TestString = s;
        }
    }
}
