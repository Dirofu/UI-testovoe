using UnityEngine;

namespace Core.Scripts.Extensions
{
	public static class ColorExtensions
	{
		public static string ToHtmlString(this Color color)
		{
			return "#" + ColorUtility.ToHtmlStringRGBA(color);
		}
	}
}
