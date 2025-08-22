using TMPro;
using UnityEngine;

namespace UI.Converter.Selector
{
	public class ConverterSelector : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _input;
		[SerializeField] private TMP_Text _result;

		public int ValueToConvert { get; private set; } = 0;

		private const string _format = "= <sprite=0 color=#00C8CA>{0}";

		private void OnEnable()
		{
			_input.onValueChanged.AddListener(OnValueChanged);
		}

		private void OnDisable()
		{
			_input.onValueChanged.RemoveListener(OnValueChanged);
		}

		public void ResetInfo()
		{
			OnValueChanged(string.Empty);
		}

		private void OnValueChanged(string newValue)
		{
			int result = 0;

			if (int.TryParse(newValue, out int validatedValue) == false || validatedValue < 0)
				_input.text = string.Empty;
			else
				result = GameModel.CoinToCreditRate * validatedValue;
			
			_result.text = string.Format(_format, result);
			ValueToConvert = validatedValue;
		}
	}
}