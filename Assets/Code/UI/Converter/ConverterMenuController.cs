using System;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using UI.Converter.Selector;

namespace UI.Converter
{
	public class ConverterMenuController : BaseMenuWindow
	{
		[SerializeField] private Button _convertButton;
		[SerializeField] private ConverterSelector _selector;

		private Guid? _convertBlockerGuid = null;

		protected override void Awake()
		{
			base.Awake();
			GameModel.OperationComplete += OnOperationComplete;
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			_convertButton.onClick.AddListener(ConvertButtonClicked);
			_convertButton.interactable = _convertBlockerGuid == null;
		}

		protected override void OnDisable()
		{
			base.OnDisable();

			_convertButton.onClick.RemoveListener(ConvertButtonClicked);
		}

		private void ConvertButtonClicked()
		{
			if (_convertBlockerGuid != null || _selector.ValueToConvert <= 0)
				return;

			_convertBlockerGuid = GameModel.ConvertCoinToCredit(_selector.ValueToConvert);
			_convertButton.interactable = false;
		}

		private void OnOperationComplete(GameModel.OperationResult result)
		{
			if (_convertBlockerGuid.HasValue == false ||
				_convertBlockerGuid.Value != result.Guid)
				return;

			_convertBlockerGuid = null;
			_convertButton.interactable = true;
			_selector.ResetInfo();
		}
	}
}