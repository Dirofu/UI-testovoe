using UnityEngine;
using System.Linq;
using CommonTools.Components;
using System.Collections.Generic;

namespace UI.MenuOpener
{
    public class MenuOpenerController : MonoSingleton<MenuOpenerController>
    {
        [SerializeField] private List<GameObject> _menus;

        private Dictionary<MenuType, IOpenableMenu> _menuByType = new();
        private Stack<IOpenableMenu> _openedMenus = new();

        private const int _startLayer = 10;

		protected override void Awake()
		{
			base.Awake();

            foreach (var menuObj in _menus)
                if (menuObj.TryGetComponent(out IOpenableMenu menu))
                _menuByType.Add(menu.Type, menu);
		}

		public void OpenMenu(MenuType menuType, bool addToStack = false)
        {
            if (_menuByType.TryGetValue(menuType, out IOpenableMenu menu) == false || _openedMenus.Contains(menu) == true)
                return;

			menu.Canvas.sortingOrder = _openedMenus.Count == 0 ? _startLayer : _openedMenus.Peek().Canvas.sortingOrder + 1;
            menu.OpenMenu();

            if (addToStack == true)
				_openedMenus.Push(menu);
		}

        public void CloseMenu(MenuType menuType)
        {
			if (_menuByType.TryGetValue(menuType, out IOpenableMenu menu) == false)
				return;

            menu.CloseMenu();

            if (_openedMenus.TryPeek(out IOpenableMenu result) == false)
                return;

            if (result == menu)
            {
                _openedMenus.Pop();
            }
            else
            {
                Stack<IOpenableMenu> updatedStack = new(_openedMenus.Where(tempMenu => tempMenu.Type != menu.Type));
                _openedMenus = updatedStack;
            }
		}

        public void CloseMenuByStack()
        {
            _openedMenus.Pop().CloseMenu();
        }
	}
}