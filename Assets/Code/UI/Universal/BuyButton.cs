using TMPro;
using SObjects;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI.Universal
{
	[RequireComponent(typeof(Button))]
	public class BuyButton : MonoBehaviour
	{
		[SerializeField] private Image _background;
		[SerializeField] private TMP_Text _text;

		private Button _button;

		public event Action ButtonClicked = delegate { };

		private const string _format = "<sprite={0} color=#000000>{1}";

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		public void UpdateButtonVisual(MoneyType type, string text)
		{
			BuyButtonConfig config = BuyButtonConfigsDatabase.Instance.GetButtonConfigByType(type);

			_background.color = config.Background;
			_text.text = string.Format(_format, config.AssetIndex, text);
			_text.spriteAsset = config.Asset;
		}

		public void ChangeButtonState(bool interactable) => _button.interactable = interactable;

		private void OnButtonClicked() => ButtonClicked.Invoke();
	}
}