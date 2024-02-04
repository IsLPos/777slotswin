using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private GameObject _vegetable;

    private void OnEnable()
    {
        if (_vegetable != null)
            _vegetable.SetActive(true);
    }

    public void Harvest()
    {
        if (Balance.instance.prayFarmerBalace > 1)
        {
            _vegetable.SetActive(false);
            Balance.instance.moneyBalace += 2;
            Balance.instance.prayFarmerBalace -= 1;
        }
    }
}
