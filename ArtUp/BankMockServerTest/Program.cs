using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Common;
using ArtUp.BankMockServer;

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
