using Exiled.API.Features;
using System;
using Exiled.Events.Handlers;
using Player = Exiled.Events.Handlers.Player;
namespace BetterCandy
{
    public class Plugin : Plugin<Config>
    {
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);
        public override string Name { get; } = "BetterCandy";
        public override Version Version { get; } = new Version(1, 2, 0);

        public EventHandlers EventHandlers;
        public static Plugin Instance;

        public override void OnEnabled()
        {

            EventHandlers = new EventHandlers();
            Instance = this;
            Player.Died += EventHandlers.OnDeath;
            Scp330.InteractingScp330 += EventHandlers.OnInteractingWithScp330;
            
            base.OnEnabled();
            
        }

        public override void OnDisabled()
        {
            Scp330.InteractingScp330 -= EventHandlers.OnInteractingWithScp330;
            Player.Died -= EventHandlers.OnDeath;
            EventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}