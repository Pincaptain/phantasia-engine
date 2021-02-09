using NUnit.Framework;
using PhantasiaEngine.Shared.Utilities;

namespace PhantasiaEngine.Test
{
    public class CryptoniteTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestHashEquality()
        {
            var ben = Cryptonite.Hash("Ben");
            var anotherBen = Cryptonite.Hash("Ben");
            
            TestContext.Out.WriteLine(ben);
            Assert.AreNotEqual(ben, anotherBen);
        }

        [Test]
        public void TestHashVerification()
        {
            var passwordHash = Cryptonite.Hash("Benjamin");
            
            const string correctPassword = "Benjamin";
            const string incorrectPassword = "Rachel";
            
            Assert.True(Cryptonite.Verify(correctPassword, passwordHash));
            Assert.False(Cryptonite.Verify(incorrectPassword, passwordHash));
        }
    }
}