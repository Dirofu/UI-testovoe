using UnityEngine;
using CommonTools.Components;

namespace SObjects
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Configs/Create new item")]
    public class ItemConfig : BaseConfig
    {
        [SerializeField] private GameModel.ConsumableTypes _type;
		[SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public GameModel.ConsumableTypes Type => _type; 
        public Sprite Icon => _icon; 
        public string Name => _name; 
        public string Description => _description;
	}
}