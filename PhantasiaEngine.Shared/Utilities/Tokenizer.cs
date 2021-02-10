using System;
using System.Linq;

namespace PhantasiaEngine.Shared.Utilities
{
    /// <summary>
    /// Tokenizer is a static class that contains methods used to
    /// create and verify timestamped tokens.
    /// </summary>
    public static class Tokenizer
    {
        /// <summary>
        /// Creates a timestamped token by appending the current time
        /// to a random generated guid and returns the token in a string format.
        /// </summary>
        /// <returns>Returns the created token in a string format</returns>
        public static string CreateTimestampedToken()
        {
            var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = Guid.NewGuid().ToByteArray();
            var token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        /// <summary>
        /// Verifies the provided token by extracting the time from it
        /// and checking if 24 hours have passed from his creation and return true/false
        /// based on that.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Returns bool based on the token validity</returns>
        public static bool VerifyTimestampedToken(string token)
        {
            var data = Convert.FromBase64String(token);
            var time = DateTime.FromBinary(BitConverter.ToInt64(data, 0));

            return time > DateTime.UtcNow.AddHours(-24);
        }
    }
}