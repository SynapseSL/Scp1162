using Synapse.Api.CustomObjects;
using Synapse.Api.Enum;
using System.Linq;
using UnityEngine;
using Ev = Synapse.Api.Events.EventHandler;

namespace Scp1162
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            Ev.Get.Player.PlayerDropItemEvent += Drop;
            Ev.Get.Round.WaitingForPlayersEvent += Wait;

            if (!SchematicHandler.Get.IsIDRegistered(PluginClass.Config.SchematicID))
                SchematicHandler.Get.SaveSchematic(new SynapseSchematic
                {
                    Name = "SCP-1162",
                    ID = 1162,
                    PrimitiveObjects = new System.Collections.Generic.List<SynapseSchematic.PrimitiveConfiguration>
                    {
                        new SynapseSchematic.PrimitiveConfiguration
                        {
                            Position = Vector3.zero,
                            Rotation = new Vector3(90f,0f,0f),
                            Color = new Color(0.1f,.01f,0.1f,0.95f),
                            PrimitiveType = PrimitiveType.Cylinder,
                            Scale = new Vector3(1.3f,0.1f,1.3f)
                        }
                    }
                }, "SCP-1162");
        }

        private void Wait()
        {
            var point = PluginClass.Config.Scp1162Location.Parse();
            scp1162Position = point.Position;
            var scp1162 = SchematicHandler.Get.SpawnSchematic(PluginClass.Config.SchematicID, scp1162Position);
            scp1162.Rotation = point.Room.GameObject.transform.rotation;
        }

        private Vector3 scp1162Position;

        private void Drop(Synapse.Api.Events.SynapseEventArguments.PlayerDropItemEventArgs ev)
        {
            if(Vector3.Distance(ev.Player.Position,scp1162Position) <= PluginClass.Config.Size)
            {
                if (PluginClass.Config.PossibleItems == null || PluginClass.Config.PossibleItems.Count == 0) return;
                ev.Allow = false;
                ev.Item.Destroy();
                ev.Player.GiveTextHint(PluginClass.Config.Message);

                var serializeditem = PluginClass.Config.PossibleItems.ElementAt(UnityEngine.Random.Range(0, PluginClass.Config.PossibleItems.Count));
                if(serializeditem.ID == -1)
                {
                    new Synapse.Api.Ragdoll(RoleType.Scp0492, "SCP-1162", ev.Player.Position, ev.Player.transform.rotation, DamageType.Unknown);
                    return;
                }

                var item = serializeditem.Parse();
                if (PluginClass.Config.Drop)
                    item.Drop(ev.Player.Position);
                else
                    item.PickUp(ev.Player);
            }
        }
    }
}
