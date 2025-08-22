using TMPro;
using UnityEngine;

namespace UI.Converter.Exchange
{
	[RequireComponent(typeof(TMP_Text))]
	public class ExchangeRate : MonoBehaviour
	{
		private TMP_Text _text;

		private const string _format = "<sprite=1 color=#D1BE3E>{0} = <sprite=0 color=#00C8CA>{1}";

		private void Awake()
		{
			_text = GetComponent<TMP_Text>();
		}

		private void OnEnable()
		{
			UpdateExchangeRate();
		}

		private void UpdateExchangeRate()
		{
			_text.text = string.Format(_format, 1, GameModel.CoinToCreditRate);
		}
	}
}