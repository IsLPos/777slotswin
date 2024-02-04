using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoad);
    }
}
