using TMPro;
using UnityEngine;

namespace UI.HUD.View
{
	public class ValueBalanceView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;

		private const string _format = "<sprite={0} color={1}>{2}";

		public void UpdateViewDisplay(int spriteIndex, string colorHEX, int count)
		{
			_text.text = string.Format(_format, spriteIndex, colorHEX, $"{count:N0}");
		}
	}
}