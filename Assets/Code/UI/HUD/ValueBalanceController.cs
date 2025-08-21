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
			_model = new ValueBalanceModel(GameModel.CoinCount);

			_view.SubscribeToModel(_model.ValueCount, GetFormatByType(_moneyType));
		}

		private string GetFormatByType(MoneyType type) => type switch
		{
			MoneyType.Coin => "<sprite name=\"Coin_0\" color=#C0A437>{0}",
			MoneyType.Credits => "<sprite= name=\"Credit_0\" color=#7AC6C8>{0}",

			_ => throw new NotImplementedException(nameof(type))
		};

		public void UpdateCoins(int amount)
		{
			_model.UpdateValue(amount);
		}
	}
}