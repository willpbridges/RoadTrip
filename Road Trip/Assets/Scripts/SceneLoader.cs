using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)){
            Load();
        }
    }

    private void Load()
    {
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}