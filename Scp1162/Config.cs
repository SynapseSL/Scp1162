using System;
using System.Collections.Generic;
using System.ComponentModel;
using Neuron.Core.Meta;
using Syml;
using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Map.Rooms;
using UnityEngine;

namespace Scp1162;

[Automatic]
[Serializable]
[DocumentSection("SCP 1162")]
public class Config : IDocumentSection
{
    public bool SpawnSchematic { get; set; } = true;

    [Description("The Shematic that should be spawned")]
    public uint SchematicID { get; set; } = 1162;

    [Description("The Position of Scp1162")]
    public RoomPoint Scp1162Location { get; set; } =
        new("Scp173", new Vector3(17f, 13.35f, 3.69f), new Vector3(90f, 0f, 0f));

    [Description("The Range of SCP-1162 in which it is active")]
    public float Size { get; set; } = 3f;

    [Description("If Enabled the new Items will be dropped")]
    public bool Drop { get; set; } = true;

    [Description("The Items which can Scp1162 gives the Player (use the id 4294967295 for a zombie ragdoll)")]
    public List<SerializedItem> PossibleItems { get; set; } = new()
    {
        new((uint)ItemType.KeycardJanitor, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardGuard, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardScientist, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardContainmentEngineer, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardResearchCoordinator, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardZoneManager, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardFacilityManager, 0, 0, Vector3.one),
        new((uint)ItemType.KeycardNTFOfficer, 0, 0, Vector3.one),
        new((uint)ItemType.Adrenaline, 0, 0, Vector3.one),
        new((uint)ItemType.Medkit, 0, 0, Vector3.one),
        new((uint)ItemType.GunCom45, 20, 0, Vector3.one),
        new((uint)ItemType.GunCOM18, 20, 0, Vector3.one),
        new((uint)ItemType.Coin, 0, 0, Vector3.one),
        new((uint)ItemType.Ammo44cal, 0, 0, Vector3.one),
        new((uint)ItemType.Ammo762x39, 0, 0, Vector3.one),
        new((uint)ItemType.Ammo9x19, 0, 0, Vector3.one),
        new((uint)ItemType.Ammo12gauge, 0, 0, Vector3.one),
        new((uint)ItemType.Flashlight, 0, 0, Vector3.one),
        new((uint)ItemType.ArmorCombat, 0, 0, Vector3.one),
        new((uint)ItemType.Radio, 0, 0, Vector3.one),
        new((uint)ItemType.Painkillers, 0, 0, Vector3.one),
        new(uint.MaxValue, 0, 0, Vector3.one)
    };
}
