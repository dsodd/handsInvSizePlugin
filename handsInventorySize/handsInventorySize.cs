using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using System.ComponentModel;
using System.Linq;

namespace handsInventorySize
{
    public class HandsInventorySize : RocketPlugin<HandsInventorySizeConfiguration>
    {
        public static HandsInventorySize Instance;

        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerUpdateGesture += GestureChange;
            Logger.Log($"[{Name}] has been loaded!");
        }

        protected override void Unload()
        {
            Instance = null;
            UnturnedPlayerEvents.OnPlayerUpdateGesture -= GestureChange;
            Logger.LogWarning($"[{Name}] has been unloaded!");
        }

        private void GestureChange(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            if (gesture != UnturnedPlayerEvents.PlayerGesture.InventoryOpen) return;

            if (player.GetPermissions().Any(x => x.Name == "modifier.ignore"))
                return;

            // default size ()
            int width = Configuration.Instance.Beta.Width;
            int height = Configuration.Instance.Beta.Height;

            if (player.HasPermission("container.sigma"))   
            {
                width = Configuration.Instance.Sigma.Width;
                height = Configuration.Instance.Sigma.Height;
            }
            else if (player.HasPermission("container.kappa"))
            {
                width = Configuration.Instance.Kappa.Width;
                height = Configuration.Instance.Kappa.Height;
            }
            else if (player.HasPermission("container.beta"))
            {
                width = Configuration.Instance.Beta.Width;
                height = Configuration.Instance.Beta.Height;
            }

            player.Inventory.items[2].resize((byte)width, (byte)height);
        }
    }
}
