using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fishingText;
    [SerializeField] private TextMeshProUGUI _farmerText;
    [SerializeField] private TextMeshProUGUI _playerText;
    
    [SerializeField] private TextMeshProUGUI _balanceMoneyText;
    [SerializeField] private TextMeshProUGUI _fishingBalanceMoneyText;
    [SerializeField] private TextMeshProUGUI _farmerBalanceMoneyText;

    private void Update()
    {
        UpdateText(_fishingText, Balance.instance.prayFishingBalace);
        UpdateText(_farmerText, Balance.instance.prayFarmerBalace);
        UpdateText(_playerText, Balance.instance.prayPlayerBalace);
        
        UpdateMoneyext(_balanceMoneyText, Balance.instance.moneyBalace);
        UpdateMoneyext(_fishingBalanceMoneyText, Balance.instance.moneyBalace);
        UpdateMoneyext(_farmerBalanceMoneyText, Balance.instance.moneyBalace);
    }

    private void UpdateText(TextMeshProUGUI text, int balance)
    {
        if (text.gameObject.activeSelf)
            text.text = balance.ToString();
    }
    private void UpdateMoneyext(TextMeshProUGUI text, int balance)
    {
        if (text.gameObject.activeSelf)
            text.text = $"{balance.ToString()}";
    }
}
