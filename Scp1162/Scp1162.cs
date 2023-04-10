using Neuron.Core.Plugins;
using Ninject;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Map.Schematic;
using UnityEngine;

namespace Scp1162;

[Plugin(
    Author = "Dimenzio",
    Name = "SCP-1162",
    Description = "Adds SCP-1162 to the game",
    Version = "1.0.0"
    )]
public class Scp1162 : ReloadablePlugin<Config,Translation>
{
    [Inject]
    public SchematicService SchematicService { get; set; }
    
    public override void EnablePlugin()
    {
        if (!SchematicService.IsIDRegistered(Config.SchematicID))
        {
            SchematicService.SaveConfiguration(new SchematicConfiguration()
            {
                Name = "SCP 1162",
                Id = Config.SchematicID,
                Primitives = new System.Collections.Generic.List<SchematicConfiguration.PrimitiveConfiguration>
                {
                    new()
                    {
                        Position = Vector3.zero,
                        Rotation = new Vector3(0f, 0f, 0f),
                        Color = new Color(0.1f, .01f, 0.1f, 0.95f),
                        PrimitiveType = PrimitiveType.Cylinder,
                        Scale = new Vector3(1.3f, 0.1f, 1.3f)
                    }
                }
            });
        }
        Logger.Info("SCP-1162 Enabled");
    }
}