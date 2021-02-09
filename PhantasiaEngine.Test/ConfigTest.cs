using NUnit.Framework;
using PhantasiaEngine.Shared.Config;

namespace PhantasiaEngine.Test
{
    public class ConfigTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestConfigSingleton()
        {
            Assert.AreSame(Config.Instance, Config.Instance);
        }

        [Test]
        public void TestConfigRead()
        {
            var config = Config.Instance;
            
            // Value not null
            Assert.IsNotNull(config.Read("app", "owner"));
            
            // Value not empty
            Assert.IsNotEmpty(config.Read("app", "version"));
            
            // Parsed value not null
            Assert.IsFalse(config.ReadBool("app", "released"));
        }
    }
}