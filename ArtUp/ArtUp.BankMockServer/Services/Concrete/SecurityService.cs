using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Data;
using ArtUp.BankMockServer.Services.Intarfaces;
using System.IO;
using System.Security.Cryptography;

namespace ArtUp.BankMockServer.Services.Concrete
{
    public class SecurityService : ISecurityService
    {

        public SecurityService(string algorithm)
        {
            AlgorithmName = algorithm;
        }
        public string AlgorithmName { get; set; }

        public string DecryptData(byte[] data, byte[] key)
        {
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create("DES");
            Algorithm.Key = key;
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

        public byte[] EncryptData(string data, byte[] key)
        {
            byte[] ClearData = Encoding.UTF8.GetBytes(data);
            
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = key;
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

        public byte[] ReadKey(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] key = new byte[fstream.Length];
                fstream.Read(key, 0, key.Length);
                return key;
            }
        }

        public bool VerifySignature(byte[] data, byte[] signature, byte[] pubKey)
        {
            bool retValue = false;
            using (CngKey key = CngKey.Import(pubKey, CngKeyBlobFormat.GenericPublicBlob))
            {
                var signingAlg = new ECDsaCng(key);
                retValue = signingAlg.VerifyData(data, signature);
                signingAlg.Clear();
            }
            return retValue;
        }
    }
}
