using R3;

namespace UI.HUD.Model
{
    public class ConsumableItemModel
    {
		private ReactiveProperty<int> _valueCount;

		public ConsumableItemModel(int initialCount = 0)
		{
			_valueCount = new(initialCount);
		}

		public Observable<int> ValueCount => _valueCount.AsObservable();

		public void UpdateValue(int amount)
		{
			_valueCount.Value = amount;
		}
	}
}