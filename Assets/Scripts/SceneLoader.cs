using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{

    #region Private methods

    private void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
        else LoadWinScene();
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
        SceneManager.LoadScene(2);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    #endregion
}
