using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CommonTools.Components
{
	//[CreateAssetMenu(fileName = "NewConfigDatabase", menuName = "Databases/Create config database")]
	/// <typeparam name="T">Database class</typeparam>
	/// <typeparam name="U">Config class</typeparam>
	public abstract class ConfigDatabase<T, U> : StaticScriptableObject<T>
		where T : ScriptableObject
		where U : BaseConfig
	{
		/// <summary> Must be serializable to be saved in scriptable object and shouldn't be readonly. </summary>
		[SerializeField, HideInInspector] protected List<U> configs = new();

		/// <summary>Returns config by id if exists, otherwise null.</summary>
		public virtual U GetConfigById(int id)
		{
			foreach (U config in configs)
			{
				if (config.id == id)
					return config;
			}

			return null;
		}

		/// <summary>Clears given collection then fills it with configs.</summary>
		public virtual void FillCollectionWithConfigs(ICollection<U> configsCollection)
		{
			if (configsCollection == null)
				return;
			configsCollection.Clear();
			foreach (U config in configs)
				configsCollection.Add(config);
		}

		/// <summary>Returns all configs as collection.</summary>
		public virtual IReadOnlyCollection<U> GetAllConfigsAsCollection() => configs;

		/// <summary>Returns all configs as list.</summary>
		public virtual IReadOnlyList<U> GetAllConfigsAsList() => configs;
		/// <summary>Returns all configs as list.</summary>
		public virtual U GetRandomConfig() => configs[Random.Range(0, configs.Count)];

		/// <summary>Reloads database (EDITOR ONLY).</summary>
		public virtual void Refresh()
		{
#if UNITY_EDITOR
			configs.Clear();

			var assetsGUIDs = AssetDatabase.FindAssets($"t:{typeof(U).FullName}", new[] { "Assets" });
			var counter = 0;

			foreach (var assetGUID in assetsGUIDs)
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
				U asset = AssetDatabase.LoadAssetAtPath<U>(assetPath);

				asset.id = counter++;
				configs.Add(asset);
			}
#endif
		}
	}
}