using System;
using System.IO;
using IniParser;
using IniParser.Model;

namespace PhantasiaEngine.Shared.Config
{
    /// <summary>
    /// <c>Config</c> contains all the methods required for reading preset
    /// project configuration options using the <c>IniParser</c> NuGet package. 
    /// </summary>
    public sealed class Config : IConfig
    {
        private static readonly Lazy<Config> LazyInstance = new Lazy<Config>(() => new Config());

        public static Config Instance => LazyInstance.Value;
        
        /// <summary>
        /// Creates a new ini file using the default configuration
        /// text provided inside <c>ConfigTemplate</c>.
        /// </summary>
        private static void RecreateIniFile()
        {
            var defaultConfig = ConfigTemplate.DefaultConfig();
            
            File.WriteAllText(DefaultPath, defaultConfig);
        }
        
        private const string DefaultPath = "Configuration.ini";
        
        private readonly IniData _iniData;

        private Config()
        {
            if (!File.Exists(DefaultPath))
            {
                RecreateIniFile();
            }
            
            _iniData = new FileIniDataParser().ReadFile("Configuration.ini");
        }

        /// <summary>
        /// Reloads the config file contents by recreating it using the
        /// default configuration text provided inside <c>ConfigTemplate</c>.
        /// </summary>
        public void Reload()
        {
            RecreateIniFile();
        }

        /// <summary>
        /// Returns a string value from the config file based on the
        /// provided section and key.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws an argument null exception if there is no value
        /// behind the provided section and key.
        /// </exception>
        /// <param name="section">The section of the config</param>
        /// <param name="key">The key of the selected section</param>
        /// <returns>The value of the key in a string format</returns>
        public string Read(string section, string key)
        {
            return _iniData[section][key];
        }

        /// <summary>
        /// Returns an int value from the config file based on the
        /// provided section and key.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws an argument null exception if there is no value
        /// behind the provided section and key.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws a format exception if the value behind the provided
        /// section and key is not an integer.
        /// </exception>
        /// <param name="section">The section of the config</param>
        /// <param name="key">The key of the selected section</param>
        /// <returns>The value of the key in an int format</returns>
        public int ReadInt(string section, string key)
        {
            return int.Parse(_iniData[section][key]);
        }

        /// <summary>
        /// Returns a bool value from the config file based on the
        /// provided section and key.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws an argument null exception if there is no value
        /// behind the provided section and key.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws a format exception if the value behind the provided
        /// section and key is not a bool.
        /// </exception>
        /// <param name="section">The section of the config</param>
        /// <param name="key">The key of the selected section</param>
        /// <returns>The value of the key in a bool format</returns>
        public bool ReadBool(string section, string key)
        {
            return bool.Parse(_iniData[section][key]);
        }

        /// <summary>
        /// Returns a float value from the config file based on the
        /// provided section and key.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws an argument null exception if there is no value
        /// behind the provided section and key.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws a format exception if the value behind the provided
        /// section and key is not a float.
        /// </exception>
        /// <param name="section">The section of the config</param>
        /// <param name="key">The key of the selected section</param>
        /// <returns>The value of the key in a float format</returns>
        public float ReadFloat(string section, string key)
        {
            return float.Parse(_iniData[section][key]);
        }

        public override string ToString()
        {
            return _iniData.ToString();
        }
    }
}