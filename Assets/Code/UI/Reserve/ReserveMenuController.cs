using UI.MenuOpener;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Reserve
{
	public class ReserveMenuController : MonoBehaviour, IOpenableMenu
	{
		[SerializeField] private Button _closeWindow;
		[SerializeField] private MenuType _menuType;

		public MenuType Type => _menuType;

		private void OnEnable()
		{
			_closeWindow.onClick.AddListener(OnWindowClose);
		}

		private void OnDisable()
		{
			_closeWindow.onClick.RemoveListener(OnWindowClose);
		}

		private void OnWindowClose()
		{
			MenuOpenerController.Instance.CloseMenu(_menuType);
		}

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