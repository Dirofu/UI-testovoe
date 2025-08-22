using R3;
using System;
using UnityEngine;
using UI.HUD.View;
using UI.HUD.Model;
using Core.Scripts.Extensions;

namespace UI.HUD.Controller
{
	[RequireComponent(typeof(ValueBalanceView))]
	public class ValueBalanceController : MonoBehaviour
	{
		[SerializeField] private MoneyType _moneyType;

		private ValueBalanceModel _model;
		private ValueBalanceView _view;

		private void Awake()
		{
			_view = GetComponent<ValueBalanceView>();
			_model = new ValueBalanceModel(GetCurrencyByType(_moneyType), _moneyType);

			SubscribeToModel(_model.ValueCount);
		}

		private void OnEnable()
		{
			GameModel.ModelChanged += UpdateValue;
			UpdateValue();
		}

		private void OnDisable()
		{
			GameModel.ModelChanged -= UpdateValue;
		}

		private void SubscribeToModel(Observable<int> countObserver)
		{
			countObserver.Subscribe(count =>
			{
				_view.UpdateViewDisplay(_model.Config.AssetIndex, _model.Config.Background.ToHtmlString(), count);
			});
		}

		private int GetCurrencyByType(MoneyType type) => type switch
		{
			MoneyType.Coin => GameModel.CoinCount,
			MoneyType.Credits => GameModel.CreditCount,

			_ => throw new NotImplementedException(nameof(type))
		};

		public void UpdateValue()
		{
			_model.UpdateValue(GetCurrencyByType(_moneyType));
		}
	}
}