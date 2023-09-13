using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private string bootstrapSceneName = "0.BootStrap";

    private void Start()
    {
    }

    // This method is called when the first scene is loaded
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is called when the first scene is unloaded
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == bootstrapSceneName)
        {
            SceneManager.LoadScene(GlobalParameters.SceneMainMenu);
        }
    }
}
