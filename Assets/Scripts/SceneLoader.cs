using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{

    #region Private methods

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    #endregion
    
    #region Public methods


    public void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentScene + 1);
    }

    public void LoadEndScene()
    {
        LoadScene(0);
    }

    #endregion
}
