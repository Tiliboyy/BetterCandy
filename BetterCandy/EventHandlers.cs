using System;
using System.Collections.Generic;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp330;
using InventorySystem.Items.Usables.Scp330;
using Respawning;
using UnityEngine;
namespace BetterCandy
{
    public class EventHandlers
    {
        public Dictionary<Exiled.API.Features.Player, int> CandyCounter = new Dictionary<Exiled.API.Features.Player, int>();

        public void OnInteractingWithScp330(InteractingScp330EventArgs ev)
        {
            if (ev.UsageCount == Plugin.Instance.Config.PickCandyTimes)
            {
                ev.ShouldSever = true;
            }
            else
            {
                ev.ShouldSever = false;
            }

            int RandomNumber = UnityEngine.Random.Range(1, Plugin.Instance.Config.MaxRandomizer);

            if (RandomNumber != Plugin.Instance.Config.ChoosenNumber) return;
            if (CandyCounter.TryGetValue(ev.Player, out var amount))
            {
                    if(amount >= Plugin.Instance.Config.MaxPinkPerLife) return;
            }
            else
            {
                CandyCounter.Add(ev.Player, 1);
            }
            ev.Candy = CandyKindID.Pink;
        }

        public void OnDeath(DiedEventArgs ev)
        {
            if (CandyCounter.ContainsKey(ev.Player))
            {
                CandyCounter.Remove(ev.Player);
            }
        }
    }
}
