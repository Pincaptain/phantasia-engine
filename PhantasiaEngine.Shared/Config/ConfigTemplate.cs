using System;

namespace PhantasiaEngine.Shared.Config
{
    public static class ConfigTemplate
    {
        public static string DefaultConfig()
        {
            return string.Join(
                Environment.NewLine,
                "[app]",
                "name=Phantasia Engine",
                "version=0.0.1",
                "owner=Borjan Gjorovski <borjan.gjorovski@outlook.com>",
                "description=A multipurpose engine for almost everything.",
                "released=false");
        }
    }
}