using Ev = Synapse.Api.Events.EventHandler;
using Synapse;
using Synapse.Api;
using System.Linq;
using UnityEngine;
using Mirror;

namespace Scp1162
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            Ev.Get.Player.PlayerDropItemEvent += Drop;
            Ev.Get.Round.WaitingForPlayersEvent += Wait;
            Ev.Get.Player.PlayerJoinEvent += Join;
        }

        private void Join(Synapse.Api.Events.SynapseEventArguments.PlayerJoinEventArgs ev) => PlaceScp1162(ev.Player);

        private void Wait() => scp1162Position = PluginClass.Config.Scp1162Location.Parse().Position;

        private Vector3 scp1162Position;

        private void Drop(Synapse.Api.Events.SynapseEventArguments.PlayerDropItemEventArgs ev)
        {
            if(Vector3.Distance(ev.Player.Position,scp1162Position) <= PluginClass.Config.Size)
            {
                if (PluginClass.Config.PossibleItems == null || PluginClass.Config.PossibleItems.Count == 0) return;
                ev.Allow = false;
                ev.Item.Destroy();
                ev.Player.GiveTextHint("You have changed your Item in <color=blue>Scp-1162");

                var serializeditem = PluginClass.Config.PossibleItems.ElementAt(UnityEngine.Random.Range(0, PluginClass.Config.PossibleItems.Count));
                if(serializeditem.ID == -1)
                {
                    Map.Get.CreateRagdoll(RoleType.Scp0492, ev.Player.Position, ev.Player.transform.rotation,Vector3.zero, default, false, ev.Player);
                    return;
                }
                var item = serializeditem.Parse();
                item.PickUp(ev.Player);
            }
        }

        private void PlaceScp1162(Player player)
        {
            var component = Server.Get.Host.ClassManager;
            var writer = NetworkWriterPool.GetWriter();
            writer.WriteVector3(scp1162Position);
            writer.WritePackedInt32(1);
            writer.WriteSingle(PluginClass.Config.Size);
            var msg = new RpcMessage
            {
                netId = component.netId,
                componentIndex = component.ComponentIndex,
                functionHash = typeof(CharacterClassManager).FullName.GetStableHashCode() * 503 + "RpcPlaceBlood".GetStableHashCode(),
                payload = writer.ToArraySegment()
            };
            player.Connection.Send(msg);
            NetworkWriterPool.Recycle(writer);
        }
    }
}
