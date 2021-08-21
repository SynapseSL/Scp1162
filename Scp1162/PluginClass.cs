using Synapse.Api.Plugin;

namespace Scp1162
{
    [PluginInformation(
        Name = "Scp1162",
        Author = "Dimenzio",
        Description = "Adds Scp1162 (the hole) to the Game",
        LoadPriority = 0,
        SynapseMajor = 2,
        SynapseMinor = 7,
        SynapsePatch = 0,
        Version = "v.1.0.1"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "Scp1162")]
        public static PluginConfig Config;

        public override void Load() => new EventHandlers();
    }
}
