using R3;
using SObjects;

namespace UI.HUD.Model
{
	public class ValueBalanceModel
	{
		private ReactiveProperty<int> _valueCount;
		private BuyButtonConfig _config;
		private MoneyType _type;

		public ValueBalanceModel(int initialCount, MoneyType type)
		{
			_valueCount = new(initialCount);
			_type = type;
			_config = BuyButtonConfigsDatabase.Instance.GetButtonConfigByType(type);
		}

		public Observable<int> ValueCount => _valueCount.AsObservable();
		public BuyButtonConfig Config => _config;
		public MoneyType Type => _type;

		public void UpdateValue(int amount)
		{
			_valueCount.Value = amount;
		}
	}
}