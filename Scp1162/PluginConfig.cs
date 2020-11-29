using System.ComponentModel;
using System.Collections.Generic;
using Synapse.Config;
using UnityEngine;

namespace Scp1162
{
    public class PluginConfig : AbstractConfigSection
    {
        [Description("The Position of Scp1162")]
        public SerializedMapPoint Scp1162Location = new SerializedMapPoint("LCZ_173", 23.91992f, 15.83f, 11.24058f);

        [Description("The size of Scp1162")]
        public float Size = 3f;

        [Description("The Items which can Scp1162 gives the Player (use the id -1 for a zombie ragdoll)")]
        public List<SerializedItem> PossibleItems = new List<SerializedItem>
        {
            new SerializedItem(-1,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardNTFLieutenant,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardScientist,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardZoneManager,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardContainmentEngineer,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Disarmer,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.WeaponManagerTablet,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardScientistMajor,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Ammo556,10,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Ammo762,10,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Ammo9mm,10,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Coin,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Flashlight,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.GunCOM15,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.KeycardGuard,0,0,0,0,Vector3.one)
        };
    }
}
