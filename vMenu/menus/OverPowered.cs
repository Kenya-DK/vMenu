using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuAPI;
using Newtonsoft.Json;
using CitizenFX.Core;
using static CitizenFX.Core.UI.Screen;
using static CitizenFX.Core.Native.API;
using static vMenuClient.CommonFunctions;
using static vMenuShared.PermissionsManager;

namespace vMenuClient
{
    public class OverPowered
    {
        // Variables
        private Menu menu;
        public bool MiscMagnetoMode { get; private set; } = UserDefaults.OverPoweredMagnetoMode;

        private void CreateMenu()
        {
            // Create the menu.
            menu = new Menu(Game.Player.Name, "Over Powered");

            MenuCheckboxItem magnetoModePlayerCheckbox = new MenuCheckboxItem("Magneto Mode", "Add a magneto that you is in corntrole of.", MiscMagnetoMode);

            if (IsAllowed(Permission.OWMagnetoMode))
            {
                menu.AddMenuItem(magnetoModePlayerCheckbox);
            }
            menu.OnCheckboxChange += (sender, item, index, _checked) =>
            {
                if (item == magnetoModePlayerCheckbox)
                {
                    MiscMagnetoMode = _checked;
                }
            };
        }

        /// <summary>
        /// Create the menu if it doesn't exist, and then returns it.
        /// </summary>
        /// <returns>The Menu</returns>
        public Menu GetMenu()
        {
            if (menu == null)
            {
                CreateMenu();
            }
            return menu;
        }
    }
}
