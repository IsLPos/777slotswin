using UnityEngine;
using UnityEngine.UI;

public class CloseStartMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    
    private bool _fadeIn;
    private bool _fadeOut;

    public void ShowUI()
    {
        _fadeIn = true;
    }

    public void HideUI()
    {
        _fadeOut = true;
    }

    private void Update()
    {
        if (_fadeIn)
        {
            _canvasGroup.gameObject.SetActive(true);
            if (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime;
                if (_canvasGroup.alpha >= 1)
                {
                    _fadeIn = false;
                }
            }
        }

        if (_fadeOut)
        {
            if (_canvasGroup.alpha >= 0)
            {
                _canvasGroup.alpha -= Time.deltaTime;
                if (_canvasGroup.alpha >= 0.9f)
                {
                    _canvasGroup.gameObject.SetActive(false);
                    _fadeOut = false;
                }
            }
        }
    }
}
