using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _tutorialHand;
    [SerializeField] private Transform[] _tutorialSteps;
    [SerializeField] private GameObject[] _uiDialogs;

    public int _currentStep = -1;

    private void Start()
    {
        _tutorialCanvas.SetActive(true);
        ShowUIDialog();
        //MoveToNextStep();
    }

    private void MoveToNextStep()
    {
        if (_currentStep < _tutorialSteps.Length)
        {
            //MoveAndLookTo(_tutorialSteps[_currentStep]);
            if ((_currentStep + 1) >= 6)
            {
                _tutorialHand.SetActive(false);
                _panel.SetActive(false);
                _tutorialCanvas.SetActive(false);
            }
            else
            {
                _currentStep++;
            }
        }
        else
        {
            _tutorialHand.SetActive(false);
            _panel.SetActive(false);
            _tutorialCanvas.SetActive(false);
        }
    }

    private void MoveAndLookTo(Transform targetTransform)
    {
        _tutorialHand.transform.DOMove(targetTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {

            });
    }

    private void ShowUIDialog()
    {
        if (_currentStep >= _tutorialSteps.Length)
        {
            _tutorialHand.SetActive(false);
            _panel.SetActive(false);
            _tutorialCanvas.SetActive(false);
        }
        else
        {
            MoveToNextStep();
            _panel.SetActive(true);
            _uiDialogs[_currentStep].SetActive(true);
        }
    }

    public void PressDialog()
    {
        _uiDialogs[_currentStep].SetActive(false);
        _panel.SetActive(false);
        MoveAndLookTo(_tutorialSteps[_currentStep]);
    }
    
    public void CheckStep(int stepIndex)
    {
        if (_currentStep == stepIndex - 1)
        {
            ShowUIDialog();
            //MoveToNextStep();
        }
    }
}