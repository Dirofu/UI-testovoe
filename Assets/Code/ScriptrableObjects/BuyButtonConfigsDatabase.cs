using UnityEngine;
using CommonTools.Components;
using System.Collections.Generic;

namespace SObjects
{
	[CreateAssetMenu(fileName = "ButtonConfigsDatabase", menuName = "Databases/Create button config database")]
	public class BuyButtonConfigsDatabase : ConfigDatabase<BuyButtonConfigsDatabase, BuyButtonConfig>
	{
		private Dictionary<MoneyType, BuyButtonConfig> _buttonConfigs = null;

		private void UpdateButtonDictionary()
		{
			_buttonConfigs = new();

			foreach (var config in configs)
				_buttonConfigs.Add(config.Type, config);
		}

		public BuyButtonConfig GetButtonConfigByType(MoneyType type)
		{
			if (_buttonConfigs == null)
				UpdateButtonDictionary();

			return _buttonConfigs[type];
		}

#if UNITY_EDITOR
		[UnityEditor.CustomEditor(typeof(BuyButtonConfigsDatabase), true)]
		private class CreatureConfigDatabaseEditor : UnityEditor.Editor
		{
			private UnityEditor.SerializedProperty _configsProp;
			private BuyButtonConfigsDatabase _database;

			private void OnEnable()
			{
				_configsProp = serializedObject.FindProperty("configs");
				_configsProp.isExpanded = true;
			}

			public override void OnInspectorGUI()
			{
				_database = target as BuyButtonConfigsDatabase;
				DrawDefaultInspector();
				if (GUILayout.Button("Refresh DB", GUILayout.Width(150)))
					_database.Refresh();
				GUILayout.Space(10);
				serializedObject.Update();
				UnityEditor.EditorUtility.SetDirty(serializedObject.targetObject);
				serializedObject.ApplyModifiedProperties();
				GUI.enabled = false;
				UnityEditor.EditorGUILayout.PropertyField(_configsProp);
				GUI.enabled = true;
			}
		}
#endif
	}
}