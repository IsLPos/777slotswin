using System;
using UnityEngine;
using TMPro;

public class SpinInvoker : MonoBehaviour
{
    public static SpinInvoker instance { get; private set; }

    public TMP_InputField _inputField;

    public event Action SpinStart;
    
    public bool canSpin = true;
        
    private void Awake()
    {
        SetSingleton();
    }

    public void Spin()
    {
        string text = _inputField.text;
        if (int.TryParse(text, out int bet))
        {
            if (canSpin)
            {
                Balance.instance.prayPlayerBalace -= bet;
                canSpin = false;
                SpinStart?.Invoke();
            }  
        }
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
