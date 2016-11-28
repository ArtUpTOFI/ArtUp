using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Common;
using ArtUp.BankMockServer;
using ArtUp.BankMockServer.Services.Concrete;
using System.Security.Cryptography;

namespace BankMockServerTest
{
    class Program
    {

        internal static CngKey aliceKeySignature;
        internal static byte[] alicePubKeyBlob;
        static void Main(string[] args)
        {
            //var a = InstanseCreator<TestClass>.GetInstance("ottakot");

            //var z = a as TestClass;

            //Console.WriteLine(a.ToString());
            //Console.WriteLine(z.TestString);

            //var inst = InstanseCreator<UserApiService>.GetInstance();
            //var service = inst as UserApiService;

            ////var uof = new UnitOfWork("BankContext");

            ////Console.WriteLine(uof.Accounts.GetAll().First().ToString());

            //var list = service.GetAllAccounts();

            //foreach (var s in list)
            //    Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            ////Transfer from account 1 to account 2

            //var result = service.CreateTransaction("2221111111113", "1111111111113", 5); 
            //Console.WriteLine(result.Item1.ToString() + result.Item2);
            //var list2 = service.GetAllAccounts();

            //foreach (var s in list)
            //    Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            ////_____________________________________

            ////Transfer from card  to account 

            //var result1 = service.CreateTransaction("1234567890123456", "2221111111113", 123, "9/20", "Yauheni", "Bychkouski",30);
            //Console.WriteLine(result1.Item1.ToString() + result1.Item2);

            //var list3 = service.GetAllAccounts();

            //foreach (var s in list)
            //    Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            ////_____________________________________

            ////Transfer from card  to account (false)

            //var result2 = service.CreateTransaction("2224567890123456", "2221111111113", 123, "20", "Yauheni", "Bychkouski", 5);
            //Console.WriteLine(result2.Item1.ToString() + result2.Item2);

            //var list4 = service.GetAllAccounts();

            //foreach (var s in list)
            //    Console.WriteLine(s.FirstName + " " + s.Money.ToString());

            ////_____________________________________

            //Console.ReadLine();



            //string data = null;
            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("http://localhost:59429/Data/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = await client.GetAsync("Data.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    data = await response.Content.ReadAsStringAsync();
            //}

            //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Event>(data);

            //Event res = await RequestData();


            var s = SymmetricEncryptionUtility.GenerateKey();

            Console.WriteLine("Protected key : ");
            foreach (var i in s)
            {
                Console.Write(i.ToString());
            }
            

            var data = "string for encrypting";

            var ed = SymmetricEncryptionUtility.EncryptData(data, s);

            Console.WriteLine("\nProtected key : ");
            foreach (var i in ed)
            {
                Console.Write(i);
            }
            Console.WriteLine("\n______________________");


            var dd = SymmetricEncryptionUtility.DecryptData(ed, s);

            Console.WriteLine("DATA: "+dd);
            Console.WriteLine("\nDescrypted data : ");
            foreach (var i in dd)
            {
                Console.Write(i.ToString());
            }

            Console.ReadLine();

            //    CreateKeys();

            //    byte[] aliceData = Encoding.UTF8.GetBytes("Alice");
            //    byte[] aliceSignature = CreateSignature(aliceData, aliceKeySignature);
            //    Console.WriteLine("Alice created signature: {0}",
            //          Convert.ToBase64String(aliceSignature));

            //    if (VerifySignature(aliceData, aliceSignature, alicePubKeyBlob))
            //    {
            //        Console.WriteLine("Подпись Алисы была успешно проверена");
            //    }
            //}

            //static void CreateKeys()
            //{
            //    aliceKeySignature = CngKey.Create(CngAlgorithm.ECDsaP256);
            //    alicePubKeyBlob = aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
            //}

            //static byte[] CreateSignature(byte[] data, CngKey key)
            //{
            //    byte[] signature;
            //    var signingAlg = new ECDsaCng(key);
            //    signature = signingAlg.SignData(data);
            //    signingAlg.Clear();
            //    return signature;
            //}

            //static bool VerifySignature(byte[] data, byte[] signature, byte[] pubKey)
            //{
            //    bool retValue = false;
            //    using (CngKey key = CngKey.Import(pubKey, CngKeyBlobFormat.GenericPublicBlob))
            //    {
            //        var signingAlg = new ECDsaCng(key);
            //        retValue = signingAlg.VerifyData(data, signature);
            //        signingAlg.Clear();
            //    }
            //    return retValue;
            //}
        }

    public class TestClass
    {
        public string TestString { get; set; }

        public TestClass(string s)
        {
            TestString = s;
        }
    }

        public static class SymmetricEncryptionUtility
        {
            private static bool _ProtectKey;
            private static string _AlgorithmName = "DES";

            public static string AlgorithmName
            {
                get { return _AlgorithmName; }
                set { _AlgorithmName = value; }
            }

            public static bool ProtectKey
            {
                get { return _ProtectKey; }
                set { _ProtectKey = value; }
            }

            public static byte[] protKey;

            public static byte[] GenerateKey()
            {
                // Создать алгоритм
                SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
                Algorithm.GenerateKey();

                // Получить ключ
                byte[] Key = Algorithm.Key;


                protKey = Key;

                return protKey;
                //if (ProtectKey)
                //{
                //    // Использовать DPAPI для шифрования ключа
                //    Key = ProtectedData.Protect(
                //        Key, null, DataProtectionScope.LocalMachine);
                //}

                // Сохранить ключ в файле key.config
                //using (FileStream fs = new FileStream(targetFile, FileMode.Create))
                //{
                //    fs.Write(Key, 0, Key.Length);
                //}
            }

            //public static void ReadKey(SymmetricAlgorithm algorithm)
            //{
            //    byte[] Key;

            //    using (FileStream fs = new FileStream(keyFile, FileMode.Open))
            //    {
            //        Key = new byte[fs.Length];
            //        fs.Read(Key, 0, (int)fs.Length);
            //    }

            //    if (ProtectKey)
            //        algorithm.Key = ProtectedData.Unprotect(Key, null, DataProtectionScope.LocalMachine);
            //    else
            //        algorithm.Key = Key;
            //}

            public static byte[] EncryptData(string data, byte[] key)
            {
                byte[] ClearData = Encoding.UTF8.GetBytes(data);

                // Создать алгоритм шифрования
                SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
                //ReadKey(Algorithm, keyFile);
                Algorithm.Key = key;
                // Зашифровать информацию
                MemoryStream Target = new MemoryStream();

                // Сгенерировать случайный вектор инициализации (IV)
                // для использования с алгоритмом
                Algorithm.GenerateIV();
                Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

                // Зашифровать реальные данные
                CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(ClearData, 0, ClearData.Length);
                cs.FlushFinalBlock();

                // Вернуть зашифрованный поток данных в виде байтового массива
                return Target.ToArray();
            }

            public static string DecryptData(byte[] data, byte[] key)
            {
                // Создать алгоритм
                SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
                //ReadKey(Algorithm, keyFile);
                Algorithm.Key = key;
                // Расшифровать информацию
                MemoryStream Target = new MemoryStream();

                // Прочитать вектор инициализации (IV)
                // и инициализировать им алгоритм
                int ReadPos = 0;
                byte[] IV = new byte[Algorithm.IV.Length];
                Array.Copy(data, IV, IV.Length);
                Algorithm.IV = IV;
                ReadPos += Algorithm.IV.Length;

                CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(),
                    CryptoStreamMode.Write);
                cs.Write(data, ReadPos, data.Length - ReadPos);
                cs.FlushFinalBlock();

                // Получить байты из потока в памяти и преобразовать их в текст
                return Encoding.UTF8.GetString(Target.ToArray());
            }
        }
    }
}
