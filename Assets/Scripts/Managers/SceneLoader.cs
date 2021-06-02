using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{

    #region Events

    public static event Action OnStartSceneLoaded;
    public static event Action OnSceneReloaded;

    #endregion
    
    #region Private methods

    private void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
        else
            LoadWinScene();
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    private void LoadWinScene()
    {
        LoadScene(4);
    }
    
    #endregion
    
    #region Public methods


    public void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentScene + 1);
    }

    public void LoadStartScene()
    {
        OnStartSceneLoaded?.Invoke();
        SceneManager.LoadScene(0);
    }

    public void ReloadCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentScene);
        Time.timeScale = 1f;
        OnSceneReloaded?.Invoke();
    }
    
    public void ExitGame()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
    #endregion
}
