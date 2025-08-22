using System;
using UnityEngine;
using UI.Reserve.View;
using UI.Reserve.Model;
using System.Threading.Tasks;

namespace UI.Reserve.Controller
{
	[RequireComponent(typeof(ReserveItemView))]
	public class ReserveItemController : MonoBehaviour
	{
		[SerializeField] private GameModel.ConsumableTypes _type;

		private ReserveItemView _view;
		private ReserveItemModel _model;

		private Guid? _buyBlockGuid = null;

		private void Awake()
		{
			_view = GetComponent<ReserveItemView>();
			_model = new(GameModel.GetConsumableCount(_type), _type);
			GameModel.OperationComplete += OnOperationComplete;
		}

		private async void OnEnable()
		{
			GameModel.ModelChanged += UpdateInfo;
			_view.BuyButtonViewClicked += BuyItem;

			UpdateInfo();

			await UpdateButtonAfterEnableMenu();
		}

		private void OnDisable()
		{
			GameModel.ModelChanged -= UpdateInfo;
			_view.BuyButtonViewClicked -= BuyItem;
		}

		private async Task UpdateButtonAfterEnableMenu()
		{
			await Task.Delay(10);
			_view.ChangeBuyButtonState(_buyBlockGuid == null);
		}

		private void UpdateInfo()
		{
			_model.UpdateValue(GameModel.GetConsumableCount(_type));
			_view.SetInfo(_model.Config.Name, _model.Config.Icon, _model.Value.ToString(), _model.Config.Description, _model.MoneyType, _model.Price);
		}

		private void BuyItem()
		{
			if (_buyBlockGuid.HasValue == true)
				return;

			_buyBlockGuid = _model.MoneyType switch
			{
				MoneyType.Coin => (Guid?)GameModel.BuyConsumableForGold(_type),
				MoneyType.Credits => (Guid?)GameModel.BuyConsumableForSilver(_type),
				_ => throw new NotImplementedException($"{nameof(_model.MoneyType)} is {_model.MoneyType} not implemented"),
			};

			_view.ChangeBuyButtonState(false);
		}

		private void OnOperationComplete(GameModel.OperationResult result)
		{
			if (_buyBlockGuid.HasValue == false ||
				_buyBlockGuid.Value != result.Guid)
				return;

			_buyBlockGuid = null;
			_view.ChangeBuyButtonState(true);
		}
	}
}