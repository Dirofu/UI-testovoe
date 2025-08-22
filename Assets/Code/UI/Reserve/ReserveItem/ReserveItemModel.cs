using R3;
using System;
using SObjects;

namespace UI.Reserve.Model
{
	public class ReserveItemModel
	{
		private ReactiveProperty<int> _valueCount;
		private GameModel.ConsumableTypes _type;
		private ItemConfig _config;
		private MoneyType _moneyType;
		private int _price;

		public ReserveItemModel(int initialCount, GameModel.ConsumableTypes type)
		{
			_valueCount = new(initialCount);
			_type = type;

			_config = ItemConfigsDatabase.Instance.GetItemConfigByType(_type);
			_moneyType = GetMoneyTypeByPricesList(GameModel.ConsumablesPrice[_type], out int price);
			_price = price;
		}

		public Observable<int> ValueCount => _valueCount.AsObservable();
		public int Value => _valueCount.CurrentValue;
		public GameModel.ConsumableTypes Type => _type;
		public ItemConfig Config => _config;
		public MoneyType MoneyType => _moneyType;
		public int Price => _price;

		public void UpdateValue(int amount)
		{
			_valueCount.Value = amount;
		}

		private MoneyType GetMoneyTypeByPricesList(GameModel.ConsumableConfig config, out int price)
		{
			if (config.CoinPrice > 0)
			{
				price = config.CoinPrice;
				return MoneyType.Coin;
			}
			else if (config.CreditPrice > 0)
			{
				price = config.CreditPrice;
				return MoneyType.Credits;
			}

			throw new ArgumentOutOfRangeException($"{nameof(GameModel.ConsumableConfig)} hasn't valide price");
		}
	}
}