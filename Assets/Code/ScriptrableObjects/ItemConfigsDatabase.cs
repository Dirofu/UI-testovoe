using UnityEngine;
using CommonTools.Components;
using System.Collections.Generic;

namespace SObjects
{
	[CreateAssetMenu(fileName = "ItemConfigsDatabase", menuName = "Databases/Create item config database")]
	public class ItemConfigsDatabase : ConfigDatabase<ItemConfigsDatabase, ItemConfig>
	{
		private Dictionary<GameModel.ConsumableTypes, ItemConfig> _items = null;

		private void UpdateItemsDictionary()
		{
			_items = new();

			foreach (var config in configs)
				_items.Add(config.Type, config);
		}

		public ItemConfig GetItemConfigByType(GameModel.ConsumableTypes type)
		{
			if (_items == null)
				UpdateItemsDictionary();

			return _items[type];
		}


#if UNITY_EDITOR
		[UnityEditor.CustomEditor(typeof(ItemConfigsDatabase), true)]
		private class CreatureConfigDatabaseEditor : UnityEditor.Editor
		{
			private UnityEditor.SerializedProperty _configsProp;
			private ItemConfigsDatabase _database;

			private void OnEnable()
			{
				_configsProp = serializedObject.FindProperty("configs");
				_configsProp.isExpanded = true;
			}

			public override void OnInspectorGUI()
			{
				_database = target as ItemConfigsDatabase;
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