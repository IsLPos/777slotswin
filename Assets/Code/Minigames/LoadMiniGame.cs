using UnityEngine;

public class LoadMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject[] _panelsToDeactivate;

    [SerializeField] private GameObject[] _panelsToAactivate;

    public void Load()
    {
        foreach (GameObject panel in _panelsToAactivate)
        {
            panel.SetActive(true);
        }
        
        foreach (GameObject panel in _panelsToDeactivate)
        {
            panel.SetActive(false);
        }
    }
}
