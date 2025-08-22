using UI.HUD.View;
using UnityEngine;
using UI.HUD.Model;
using UnityEngine.UI;
using UI.MenuOpener;

namespace UI.HUD.Controller
{
	[RequireComponent(typeof(ConsumableItemView))]
	public class ConsumableItemController : MonoBehaviour
	{
		[SerializeField] private GameModel.ConsumableTypes _consumableType;

		private ConsumableItemView _view;
		private ConsumableItemModel _model;
		private Button _button;

		private void Awake()
		{
			_view = GetComponent<ConsumableItemView>();
			_button = GetComponentInChildren<Button>();
			_model = new ConsumableItemModel(GameModel.GetConsumableCount(_consumableType), _consumableType);

			if (_button == null)
				Debug.LogError($"{nameof(_button)} cannot find component in children of {gameObject.name}");

			_view.SubscribeToModel(_model.ValueCount);
		}

		private void OnEnable()
		{
			GameModel.ModelChanged += UpdateValue;
			_button.onClick.AddListener(OnButtonClick);
			_view.SetInfo(_model.Config.Icon, GameModel.GetConsumableCount(_consumableType));
		}

		private void OnDisable()
		{
			GameModel.ModelChanged -= UpdateValue;
			_button.onClick.RemoveListener(OnButtonClick);
		}

		public void UpdateValue()
		{
			_model.UpdateValue(GameModel.GetConsumableCount(_consumableType));
		}

		private void OnButtonClick()
		{
			MenuOpenerController.Instance.OpenMenu(MenuType.Reserve, true);
		}
	}
}