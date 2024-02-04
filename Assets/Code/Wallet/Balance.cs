using System;
using UnityEngine;
using TMPro;

public class Balance : MonoBehaviour
{
    public static Balance instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _winText;

    [SerializeField] public int moneyBalace;

    [SerializeField] public int prayFishingBalace;
    [SerializeField] public int prayFarmerBalace;
    [SerializeField] public int prayPlayerBalace;

    [SerializeField] private int _praysForCommonSign;
    [SerializeField] private int _praysForTier3Sign;
    [SerializeField] private int _praysForTier4Sign;

    private int _lastWin;
    
    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        Slot.instance.ComboFound += AddPray;
    }

    private void Update()
    {
        ChangeText();
    }

    private void AddPray(int id)
    {
        Debug.Log("Added");
        switch (id)
        {
            case 0:
                prayFishingBalace += _praysForCommonSign;
                _lastWin = _praysForCommonSign * 9;
                break;
            case 1:
                prayFarmerBalace += _praysForCommonSign;
                _lastWin = _praysForCommonSign * 9;
                break;
            case 2:
                prayPlayerBalace += _praysForCommonSign;
                _lastWin = _praysForCommonSign * 9;
                break;
            case 3:
                AllPraysPlusBalance(_praysForTier3Sign);
                break;
            case 4:
                AllPraysPlusBalance(_praysForTier4Sign);
                break;
        }
    }

    private void ChangeText()
    {
        _winText.text = _lastWin.ToString();
    }
    
    private void AllPraysPlusBalance(int amount)
    {
        prayFishingBalace += amount;
        prayFarmerBalace += amount;
        prayPlayerBalace += amount;
        _lastWin = amount * 9;
    }
    
    private void SetSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        
        Destroy(gameObject);
    }
}
