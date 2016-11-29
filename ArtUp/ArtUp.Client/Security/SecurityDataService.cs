using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ArtUp.Client.Security
{
    public static class SecurityDataService
    {
        public static Tuple<byte[], CngKey> CreateKeys()
        {
            var ProtKey = CngKey.Create(CngAlgorithm.ECDsaP256);
            var PubKey = ProtKey.Export(CngKeyBlobFormat.GenericPublicBlob);

            return new Tuple<byte[], CngKey>(PubKey, ProtKey);
        }

        public static byte[] CreateSignature(byte[] data, CngKey key)
        {
            byte[] signature;
            var signingAlg = new ECDsaCng(key);
            signature = signingAlg.SignData(data);
            signingAlg.Clear();
            return signature;
        }

        public static byte[] EncryptData(string data, byte[] key)
        {
            byte[] ClearData = Encoding.UTF8.GetBytes(data);

            // Создать алгоритм шифрования
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create("DES");
            Algorithm.Key = key;
            MemoryStream Target = new MemoryStream();

            // Сгенерировать случайный вектор инициализации (IV)
            // для использования с алгоритмом
            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            // Зашифровать данные
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData, 0, ClearData.Length);
            cs.FlushFinalBlock();

            // Вернуть зашифрованный поток данных в виде байтового массива
            return Target.ToArray();
        }
    }
}