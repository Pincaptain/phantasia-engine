using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PhantasiaEngine.Shared.Utilities
{
    /// <summary>
    /// <c>Cryptonite</c> contains all the methods required for hashing and verifying strings
    /// using the most up-to-date methods and algorithms.
    /// </summary>
    /// <example>
    /// <code>
    /// var password = "password";
    /// var passwordHash = Cryptonite.Hash(password);
    /// 
    /// var correctPasswordAttempt = "password";
    /// var incorrectPasswordAttempt = "wrong";
    /// 
    /// var correctPassword = Cryptonite.Verify(correctPasswordAttempt, passwordHash); // True
    /// var incorrectPassword = Cryptonite.Verify(incorrectPasswordAttempt, passwordHash); // False
    /// </code>
    /// </example>
    public static class Cryptonite
    {
        private const int SaltSize = 16;
        private const int IterCount = 10000;
        private const int SubkeyLength = 32;
        private const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1;
        
        /// <summary>
        /// Hashes the provided value using the Pbkdf2 function and
        /// returns the hashed value in a string format.
        /// </summary>
        /// <param name="value">Value to hash</param>
        /// <returns>String of the hashed value</returns>
        public static string Hash(string value)
        {
            var salt = new byte[SaltSize];

            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(salt);

            var subkey = KeyDerivation.Pbkdf2(value, salt, Pbkdf2Prf, IterCount, SubkeyLength);
            
            var hashBytes = new byte[1 + SaltSize + SubkeyLength];
            hashBytes[0] = 0x00;
            
            Buffer.BlockCopy(salt, 0, hashBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, hashBytes, 1 + SaltSize, SubkeyLength);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Verifies by hashing the value and matching it with the provided hash.
        /// Returns true if the hashes match and false otherwise.
        /// </summary>
        /// <param name="value">Value to compare with hash</param>
        /// <param name="hash">Hash to compare value with</param>
        /// <returns>True if the hash values are equal and false otherwise</returns>
        public static bool Verify(string value, string hash)
        {
            var hashBytes = Convert.FromBase64String(hash);

            if (hashBytes.Length != 1 + SaltSize + SubkeyLength) return false;
            
            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashBytes, 1, salt, 0, salt.Length);

            var subkey = new byte[SubkeyLength];
            Buffer.BlockCopy(hashBytes, 1 + salt.Length, subkey, 0, subkey.Length);

            var valueSubkey = KeyDerivation.Pbkdf2(value, salt, Pbkdf2Prf, IterCount, SubkeyLength);

            return CryptographicOperations.FixedTimeEquals(subkey, valueSubkey);
        }
    }
}