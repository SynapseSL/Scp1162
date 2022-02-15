using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Scp1162
{
    public class PluginConfig : AbstractConfigSection
    {
        public bool SpawnShematic { get; set; } = true;

        [Description("The Shematic that should be spawned")]
        public int ShematicID { get; set; } = 1162;

        [Description("The Position of Scp1162")]
        public SerializedMapPoint Scp1162Location { get; set; } = new SerializedMapPoint("LCZ_173", 22.5f, 18.1f, 5f);

        [Description("The Range of SCP-1162 in which it is active")]
        public float Size { get; set; } = 3f;

        [Description("If Enabled the new Items will be dropped")]
        public bool Drop { get; set; } = false;

        [Description("The Items which can Scp1162 gives the Player (use the id -1 for a zombie ragdoll)")]
        public List<SerializedItem> PossibleItems { get; set; } = new List<SerializedItem>
        {
            new SerializedItem(-1, 0, 0, Vector3.one),
        };

        public string Message { get; set; } = "You have changed your Item in <color=blue>Scp-1162</color>";
    }
}
