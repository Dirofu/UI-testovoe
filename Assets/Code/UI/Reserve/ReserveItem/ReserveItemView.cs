using TMPro;
using System;
using UnityEngine;
using UI.Universal;
using UnityEngine.UI;

namespace UI.Reserve.View
{
	public class ReserveItemView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _title;
		[SerializeField] private Image _image;
		[SerializeField] private TMP_Text _value;
		[SerializeField] private TMP_Text _description;
		[SerializeField] private BuyButton _buyButton;

		public event Action BuyButtonViewClicked = delegate { };

		private void OnEnable()
		{
			_buyButton.ButtonClicked += BuyButtonClicked;
		}

		private void OnDisable()
		{
			_buyButton.ButtonClicked -= BuyButtonClicked;
		}

		public void SetInfo(string title, Sprite image, string value, string description, MoneyType priceType, int price)
		{
			_title.text = title;
			_image.sprite = image;
			_value.text = value;
			_description.text = description;

			_buyButton.UpdateButtonVisual(priceType, $"{price}");
		}

		public void ChangeBuyButtonState(bool interactable)
		{
			_buyButton.ChangeButtonState(interactable);
		}

		private void BuyButtonClicked()
		{
			BuyButtonViewClicked.Invoke();
		}
	}
}