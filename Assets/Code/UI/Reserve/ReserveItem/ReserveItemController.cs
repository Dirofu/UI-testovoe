using System;
using UnityEngine;
using UI.Reserve.View;
using UI.Reserve.Model;

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
		}

		private void OnEnable()
		{
			GameModel.ModelChanged += UpdateInfo;
			GameModel.OperationComplete += OnOperationComplete;
			_view.BuyButtonViewClicked += BuyItem;
			UpdateInfo();
		}

		private void OnDisable()
		{
			GameModel.OperationComplete -= OnOperationComplete;
			GameModel.ModelChanged -= UpdateInfo;
			_view.BuyButtonViewClicked -= BuyItem;
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

			switch (_model.MoneyType)
			{
				case MoneyType.Coin:
					_buyBlockGuid = GameModel.BuyConsumableForGold(_type);
					break;
				case MoneyType.Credits:
					_buyBlockGuid = GameModel.BuyConsumableForSilver(_type);
					break;
				default:
					throw new NotImplementedException($"{nameof(_model.MoneyType)} is {_model.MoneyType} not implemented");
			}

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