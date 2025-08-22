using TMPro;
using UnityEngine;
using CommonTools.Components;

namespace SObjects
{
    [CreateAssetMenu(fileName = "New Buy button", menuName = "Configs/Create new buy button")]
    public class BuyButtonConfig : BaseConfig
    {
		[SerializeField] private MoneyType _moneyType;
		[SerializeField] private Color _backgroundColor;
		[SerializeField] private TMP_SpriteAsset _asset;
		[SerializeField] private int _assetIndex;

		public MoneyType Type => _moneyType;
		public Color Background => _backgroundColor;
		public TMP_SpriteAsset Asset => _asset;
		public int AssetIndex => _assetIndex;
	}
}