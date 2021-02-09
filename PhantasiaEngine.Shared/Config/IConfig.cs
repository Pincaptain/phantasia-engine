namespace PhantasiaEngine.Shared.Config
{
    public interface IConfig
    {
        public void Reload();
        public string Read(string section, string key);
        public int ReadInt(string section, string key);
        public float ReadFloat(string section, string key);
        public bool ReadBool(string section, string key);
    }
}