using R3;
using SObjects;

namespace UI.HUD.Model
{
    public class ConsumableItemModel
    {
		private ReactiveProperty<int> _valueCount;
		private GameModel.ConsumableTypes _consumableType;
		private ItemConfig _config;

		public ConsumableItemModel(int initialCount, GameModel.ConsumableTypes consumableType)
		{
			_valueCount = new(initialCount);
			_consumableType = consumableType;
			_config = ItemConfigsDatabase.Instance.GetItemConfigByType(_consumableType);
		}

		public Observable<int> ValueCount => _valueCount.AsObservable();
		public ItemConfig Config => _config;
		public GameModel.ConsumableTypes Type => _consumableType;
		
		public void UpdateValue(int amount)
		{
			_valueCount.Value = amount;
		}
	}
}