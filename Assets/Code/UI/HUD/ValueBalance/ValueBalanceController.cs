using System;
using UI.HUD.Model;
using UI.HUD.View;
using UnityEngine;

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
			_model = new ValueBalanceModel(GetCurrencyByType(_moneyType));

			_view.SubscribeToModel(_model.ValueCount, GetFormatByType(_moneyType));
		}

		private void OnEnable()
		{
			GameModel.ModelChanged += UpdateCoins;
		}

		private void OnDisable()
		{
			GameModel.ModelChanged -= UpdateCoins;
		}

		private string GetFormatByType(MoneyType type) => type switch
		{
			MoneyType.Coin => "<sprite name=\"Coin_0\" color=#C0A437>{0}",
			MoneyType.Credits => "<sprite name=\"Credit_0\" color=#7AC6C8>{0}",

			_ => throw new NotImplementedException(nameof(type))
		};

		private int GetCurrencyByType(MoneyType type) => type switch
		{
			MoneyType.Coin => GameModel.CoinCount,
			MoneyType.Credits => GameModel.CreditCount,

			_ => throw new NotImplementedException(nameof(type))
		};

		public void UpdateCoins()
		{
			_model.UpdateValue(GetCurrencyByType(_moneyType));
		}
	}
}