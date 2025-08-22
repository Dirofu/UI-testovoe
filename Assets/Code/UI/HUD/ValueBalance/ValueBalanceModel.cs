using R3;

namespace UI.HUD.Model
{
	public class ValueBalanceModel
	{
		private ReactiveProperty<int> _valueCount;

		public ValueBalanceModel(int initialCount = 0)
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