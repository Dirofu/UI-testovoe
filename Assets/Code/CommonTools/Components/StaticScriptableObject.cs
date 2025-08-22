using UnityEngine;

namespace CommonTools.Components
{
	public abstract class StaticScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		private static T _instance;

		public static T Instance => _instance ? _instance : _instance = Resources.Load(typeof(T).Name) as T;
	}
}
