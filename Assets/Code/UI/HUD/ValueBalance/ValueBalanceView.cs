using R3;
using TMPro;
using UnityEngine;

namespace UI.HUD.View
{
	public class ValueBalanceView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;

		private string _format;

		public void SubscribeToModel(Observable<int> countObserver, string format)
		{
			_format = format;

			countObserver.Subscribe(count =>
			{
				UpdateCreditDisplay(count);
			});
		}

		public void UpdateCreditDisplay(int count)
		{
			_text.text = string.Format(_format, $"{count:N0}");
		}
	}
}