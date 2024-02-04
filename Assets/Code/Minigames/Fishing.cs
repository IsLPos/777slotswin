using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstText;
    [SerializeField] private TextMeshProUGUI _secondText;
    [SerializeField] private TextMeshProUGUI _ThirdText;

    [SerializeField] private LineRenderer _lineRenderer;

    private bool _canFishing = true;
    private float duration = 2.0f;
    private Vector3 _oldPos = Vector3.zero;

    private void OnEnable()
    {
        if (_oldPos != Vector3.zero)
            _lineRenderer.SetPosition(1, _oldPos);
    }

    private void Update()
    {
        SetText();
    }

    public void StartFishing()
    {
        StartCoroutine(MoveLineRenderer());
    }
    
    private IEnumerator MoveLineRenderer()
    {
        if (_canFishing && Balance.instance.prayFishingBalace > 0)
        {
            _canFishing = false;
            Vector3 startPos = _lineRenderer.GetPosition(1);
            _oldPos = startPos;

            Vector3 endPos = new Vector3(-0.1f, -3f, 0f);

            float elapsed = 0f;

            while (elapsed < duration)
            {
                _lineRenderer.SetPosition(1, Vector3.Lerp(startPos, endPos, elapsed / duration));

                elapsed += Time.deltaTime;

                yield return null;
            }
        
            _lineRenderer.SetPosition(1, endPos);
            Balance.instance.moneyBalace += Balance.instance.prayFishingBalace * 2;
            Balance.instance.prayFishingBalace = 0;
            _canFishing = true;
        }
    }
    
    private void SetText()
    {
        _firstText.text = $"+{(Balance.instance.prayFishingBalace * 0.5).ToString()}$";
        _secondText.text = $"+{(Balance.instance.prayFishingBalace * 1).ToString()}$";
        _ThirdText.text = $"+{(Balance.instance.prayFishingBalace * 2).ToString()}$";
    }
}
