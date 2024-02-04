using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sign[] _signs;
    [SerializeField] private float _timeToNextSign;

    public event Action SpinFinished;
    
    [field: SerializeField] public Sign mySign { get; private set; }

    private void Start()
    {
        SpinFinished += Slot.instance.CheckCombinations;
    }

    public void Spin()
    {
        Slot.instance.ClearLines();
        StartCoroutine(RandomSign());
    }

    private IEnumerator RandomSign()
    {
        int random = Random.Range(3, 20);

        foreach (Sign sign in _signs)
        {
            sign.gameObject.SetActive(false);
        }

        for (int i = 0; i < _signs.Length; i++)
        {
            _signs[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(_timeToNextSign);
            _signs[i].gameObject.SetActive(false);
        }

        random %= _signs.Length; // Обнуляем random, чтобы не выходил за пределы массива

        _signs[random].gameObject.SetActive(true);
        mySign = _signs[random];
        yield return new WaitForSeconds(0.05f);
        SpinFinished?.Invoke();
        SpinInvoker.instance.canSpin = true;
    }
}
