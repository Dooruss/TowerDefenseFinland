using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void Exit()
    {
        Application.Quit();
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}