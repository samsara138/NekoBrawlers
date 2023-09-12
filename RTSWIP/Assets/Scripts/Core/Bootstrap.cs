using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    // Specify the names of your scenes
    public string bootstrapSceneName = "0.BootStrap";
    public string firstSceneName = "GameHUD";
    public string secondSceneName = "TestGame";

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
            SceneManager.LoadScene(firstSceneName, LoadSceneMode.Additive);
        }else if (scene.name == firstSceneName)
        {
            SceneManager.LoadScene(secondSceneName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(bootstrapSceneName);
        }
    }
}
