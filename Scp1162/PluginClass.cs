using Synapse.Api.Plugin;

namespace Scp1162
{
    [PluginInformation(
        Name = "Scp1162",
        Author = "Dimenzio",
        Description = "Adds Scp1162 (the hole) to the Game",
        LoadPriority = int.MinValue,
        SynapseMajor = 2,
        SynapseMinor = 2,
        SynapsePatch = 0,
        Version = "v.1.0.0"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "Scp1162")]
        public static PluginConfig Config;

        public override void Load() => new EventHandlers();
    }
}
