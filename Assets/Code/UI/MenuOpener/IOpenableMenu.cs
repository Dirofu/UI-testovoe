using UnityEngine;

namespace UI.MenuOpener
{
    public interface IOpenableMenu
    {
        public Canvas Canvas { get; }
        public MenuType Type { get; }

		public void OpenMenu();
        public void CloseMenu();
    }
}