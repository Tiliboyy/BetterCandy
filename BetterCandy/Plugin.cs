using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
namespace BetterCandy
{
    public class Plugin : Plugin<Config>
    {
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);
        public override string Name { get; } = "BetterCandy";
        public override Version Version { get; } = new Version(1, 1, 0);

        public static Plugin Singleton;
        public Handlers.Player2 player;

        public override void OnEnabled()
        {

            Singleton = this;
            player = new Handlers.Player2(this);

            Player.InteractingScp330 += player.OnInteractingWithScp330;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.InteractingScp330 -= player.OnInteractingWithScp330;

            Singleton = null;
            player = null;

            base.OnDisabled();
        }
    }
}