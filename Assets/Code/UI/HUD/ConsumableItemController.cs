using UI.HUD.Model;
using UI.HUD.View;
using UnityEngine;

namespace UI.HUD.Controller
{
	[RequireComponent(typeof(ConsumableItemView))]
	public class ConsumableItemController : MonoBehaviour
	{
		[SerializeField] private GameModel.ConsumableTypes _consumableType;

		private ConsumableItemView _view;
		private ConsumableItemModel _model;

		private void Awake()
		{
			_view = GetComponent<ConsumableItemView>();
			_model = new ConsumableItemModel(GameModel.GetConsumableCount(_consumableType));

			_view.SubscribeToModel(_model.ValueCount);
		}

		public void UpdateValue(int value)
		{
			_model.UpdateValue(value);
		}
	}
}