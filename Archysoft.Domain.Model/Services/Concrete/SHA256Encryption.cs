using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Archysoft.Domain.Model.Services.Concrete
{
    public class Sha256Encryption
    {
        public static string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            return result.ToString();
        }

        public static string Sha256HexHashString(string stringIn)
        {
            string hashString;
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(stringIn));
                hashString = ToHex(hash, false);
            }

            return hashString;
        }
    }
}
