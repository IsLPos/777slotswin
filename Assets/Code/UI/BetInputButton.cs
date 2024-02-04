using System;
using UnityEngine;
using TMPro;

public class BetInputButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    private void Start()
    {
        _inputField.text = 5.ToString();
    }

    public void AddBet()
    {
        int oldBet = int.Parse(_inputField.text);
        int newBet = oldBet + 5;
        _inputField.text = newBet.ToString();
    }
    
    public void TakeBet()
    {
        int oldBet = int.Parse(_inputField.text);
        int newBet = oldBet - 5;
        
        if (newBet >= 5)
            _inputField.text = newBet.ToString();
    }
}
