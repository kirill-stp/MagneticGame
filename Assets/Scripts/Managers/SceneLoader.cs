using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
    #region Events

    public static event Action OnStartSceneLoaded;

    #endregion


    #region Private methods

    private void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
        else
            LoadWinScene(); // No Java code plz. On new line or in {} braces
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void LoadWinScene()
    {
        SceneManager.LoadScene(1);
    }

    #endregion


    #region Public methods

    public void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentScene + 1);
    }

    public void LoadLoseScene()
    {
        LoadScene(0);
    }

    public void LoadStartScene()
    {
        OnStartSceneLoaded?.Invoke();
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        // Add logic for exit in editor
        Application.Quit();
    }

    #endregion
}
