using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace BetterCandy.Handlers
{
    public class Player2
    {
        private readonly Plugin plugin;
        public Player2(Plugin plugin) => this.plugin = plugin;

        public void OnInteractingWithScp330(InteractingScp330EventArgs ev)
        {
            if (ev.UsageCount == plugin.Config.PickCandyTimes)
            {
                ev.ShouldSever = true;
            }
            else
            {
                ev.ShouldSever = false;
            }

            int RandomNumber = Random.Range(1, Plugin.Singleton.Config.MaxRandomizer);

            if (RandomNumber == plugin.Config.ChoosenNumber)
            {
                ev.IsAllowed = false;
                ev.Player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);
                Debug.Log("Cu de anao pelado sem roupa sexooxoxoxoaxoasxosdaosdao");
            }
        }
    }
}
