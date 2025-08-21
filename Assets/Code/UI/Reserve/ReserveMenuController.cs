using UnityEngine;
using UnityEngine.UI;

public class ReserveMenuController : MonoBehaviour
{
	[SerializeField] private Button _buyMedicine;
	[SerializeField] private Button _buyArmorPlate;
	[SerializeField] private Button _closeWindow;

	private void OnEnable()
	{
		_buyMedicine.onClick.AddListener(OnBuyMedicine);
		_buyArmorPlate.onClick.AddListener(OnBuyArmorPlate);
		_closeWindow.onClick.AddListener(OnWindowClose);
	}

	private void OnDisable()
	{
		_buyMedicine.onClick.RemoveListener(OnBuyMedicine);
		_buyArmorPlate.onClick.RemoveListener(OnBuyArmorPlate);
		_closeWindow.onClick.RemoveListener(OnWindowClose);
	}

	private void OnBuyMedicine()
	{
		GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
	}

	private void OnBuyArmorPlate()
	{
		GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
	}

	private void OnWindowClose()
	{
		gameObject.SetActive(false);
	}
}
