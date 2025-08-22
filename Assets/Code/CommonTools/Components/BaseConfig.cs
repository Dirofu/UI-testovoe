using System;
using UnityEngine;

namespace CommonTools.Components
{
	[Serializable]
	public abstract class BaseConfig : ScriptableObject
	{
		[SerializeField, HideInInspector] public int id;
	}
}