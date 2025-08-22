using System;
using UI.MenuOpener;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD.Converter
{
    public class CurrencyConverter : MonoBehaviour
    {
        private Button _button;

		private void Awake()
		{
			_button = GetComponentInChildren<Button>();

			if (_button == null)
				throw new ArgumentNullException($"{nameof(_button)}");
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OpenConverterMenu);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OpenConverterMenu);
		}

		private void OpenConverterMenu()
		{
			MenuOpenerController.Instance.OpenMenu(MenuType.ValueConverter);
		}
	}
}