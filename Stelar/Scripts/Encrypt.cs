using System;
using System.Text;

namespace Moose.Encrypt
{
    class Encrypt
    {
        public string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}