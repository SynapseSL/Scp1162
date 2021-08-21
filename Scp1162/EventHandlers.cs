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
            Ev.Get.Player.PlayerJoinEvent += Join;
        }

        private void Join(Synapse.Api.Events.SynapseEventArguments.PlayerJoinEventArgs ev) => ev.Player.PlaceBlood(scp1162Position, 1, PluginClass.Config.Size);

        private void Wait() => scp1162Position = PluginClass.Config.Scp1162Location.Parse().Position;

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
                    new Synapse.Api.Ragdoll(RoleType.Scp0492, ev.Player.Position, ev.Player.transform.rotation, Vector3.zero, default, false, ev.Player);
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
