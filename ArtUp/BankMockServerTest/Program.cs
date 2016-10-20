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
                Console.WriteLine(s.FirstName);

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
