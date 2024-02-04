using System;
using UnityEngine;
using UnityEngine.UI;

public class SpinButtonAdd : MonoBehaviour
{
   private Button _button;

   private void Start()
   {
      _button = GetComponent<Button>();

      _button.onClick.AddListener(SpinInvoker.instance.Spin);
      
      Debug.Log(SpinInvoker.instance.name);
   }
}
