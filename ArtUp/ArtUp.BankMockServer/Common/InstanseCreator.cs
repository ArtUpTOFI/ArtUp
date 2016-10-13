using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Common
{
    public static class InstanseCreator<T>
    {
        public static object GetInstance()
        {
            Type TestType = typeof(T);
            
            System.Reflection.ConstructorInfo ci1 = TestType.GetConstructor(new Type[] { });

            return ci1 == null ? null : ci1.Invoke(new object[] { });
        }

        public static object GetInstance(string connectionString)
        {
            Type TestType = typeof(T);
            
            System.Reflection.ConstructorInfo ci2 = TestType.GetConstructor(new Type[] { typeof(string) });
            
            return ci2 == null ? null : ci2.Invoke(new object[] { connectionString });
        }
    }
}
