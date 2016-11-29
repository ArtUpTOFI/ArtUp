using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Data;

namespace ArtUp.BankMockServer.Services.Intarfaces
{
    public interface ISecurityService
    {
        byte[] EncryptData(string data, byte[] key);

        string DecryptData(byte[] data, byte[] key);

        byte[] ReadKey(string path);

        bool VerifySignature(byte[] data, byte[] signature, byte[] pubKey);
    }
}
