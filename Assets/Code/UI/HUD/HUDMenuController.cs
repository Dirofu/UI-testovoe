using UI.MenuOpener;
using UnityEngine;

namespace UI.HUD
{
	public class HUDMenuController : MonoBehaviour, IOpenableMenu
	{
		[SerializeField] private MenuType _menuType;

		public MenuType Type => _menuType;

		public void OpenMenu()
		{
			gameObject.SetActive(true);
		}

		public void CloseMenu()
		{
			gameObject.SetActive(false);
		}
	}
}