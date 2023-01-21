using System;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Scp330;
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

            int RandomNumber = UnityEngine.Random.Range(1, plugin.Config.MaxRandomizer);

            if (RandomNumber == plugin.Config.ChoosenNumber)
            {
                ev.IsAllowed = false;
                ev.Player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);
            }
        }                    
    }
}
