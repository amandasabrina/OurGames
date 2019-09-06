using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OurGames.Common.Security
{
    public static class HMACSHA512Helper
    {
        public static bool IsAValidHash(string s, byte[] key, byte[] hash)
        {
            using (var hmac = new HMACSHA512(key))
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(s)) == hash;
        }

        public static (byte[] passwordHash, byte[] saltHash) CreateHMACSHA12Hash(this string s)
        {
            using (var hmac = new HMACSHA512())
                return (hmac.Key, hmac.ComputeHash(Encoding.UTF8.GetBytes(s)));
        }
    }
}
