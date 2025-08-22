using UI.MenuOpener;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Base
{
	[RequireComponent(typeof(Canvas))]
    public class BaseMenuWindow : MonoBehaviour, IOpenableMenu
	{
		[SerializeField] private GameObject _root;
		[SerializeField] private Button _closeWindow;
		[SerializeField] private MenuType _menuType;

		private Canvas _canvas;

		public Canvas Canvas => _canvas;
		public MenuType Type => _menuType;

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
		}

		private void OnEnable()
		{
			if (_closeWindow != null)
				_closeWindow.onClick.AddListener(OnWindowClose);
		}

		private void OnDisable()
		{
			if (_closeWindow != null)
				_closeWindow.onClick.RemoveListener(OnWindowClose);
		}

		public void OpenMenu()
		{
			_root.SetActive(true);
		}

		public void CloseMenu()
		{
			_root.SetActive(false);
		}

		protected virtual void OnWindowClose()
		{
			MenuOpenerController.Instance.CloseMenu(_menuType);
		}

	}
}