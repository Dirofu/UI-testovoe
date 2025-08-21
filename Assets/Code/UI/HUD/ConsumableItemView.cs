using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD.View
{
	public class ConsumableItemView : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private TMP_Text _text;

		public void SetInfo(Sprite sprite, int value)
		{
			_image.sprite = sprite;
			_text.text = $"{value}";
		}

		public void SubscribeToModel(Observable<int> countObserver)
		{
			countObserver.Subscribe(count =>
			{
				UpdateValue(count);
			});
		}

		public void UpdateValue(int value) => _text.text = $"{value}";
	}
}