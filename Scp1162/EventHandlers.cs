using Neuron.Core.Events;
using Neuron.Core.Meta;
using Ninject;
using PlayerRoles;
using Synapse3.SynapseModule.Enums;
using Synapse3.SynapseModule.Events;
using Synapse3.SynapseModule.Map.Objects;
using Synapse3.SynapseModule.Map.Schematic;
using UnityEngine;

namespace Scp1162;

[Automatic]
public class EventHandlers : Listener
{
    [Inject]
    public Scp1162 Plugin { get; set; }
    
    [Inject]
    public SchematicService SchematicService { get; set; }
    
    private Vector3 scp1162Position;

    [EventHandler]
    public void Wait(RoundWaitingEvent _)
    {
        var point = Plugin.Config.Scp1162Location;
        scp1162Position = point.GetMapPosition();
        if (Plugin.Config.SpawnSchematic)
            SchematicService.SpawnSchematic(Plugin.Config.SchematicID, scp1162Position, point.GetMapRotation());
    }

    [EventHandler]
    public void Drop(DropItemEvent ev)
    {
        if (Vector3.Distance(ev.Player.Position, scp1162Position) > Plugin.Config.Size) return;
        if (Plugin.Config.PossibleItems == null || Plugin.Config.PossibleItems.Count == 0) return;
        ev.Allow = false;
        ev.ItemToDrop.Destroy();
        var trans = Plugin.Translation.Get(ev.Player);
        ev.Player.SendHint(trans.Message, trans.Duration);

        var serializedItem = Plugin.Config.PossibleItems[Random.Range(0, Plugin.Config.PossibleItems.Count)];
        if (serializedItem.ID == uint.MaxValue)
        {
            new SynapseRagDoll(RoleTypeId.Scp0492, ev.Player.Position, Quaternion.identity, Vector3.one, ev.Player,
                DamageType.Unknown, ev.Player.NickName);
            return;
        }

        var item = serializedItem.Parse();
        if (Plugin.Config.Drop)
            item.Drop(ev.Player.Position);
        else
            item.EquipItem(ev.Player);
    }
}
