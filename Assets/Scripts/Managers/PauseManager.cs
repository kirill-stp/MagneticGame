using UnityEngine;

public class PauseManager : MonoBehaviour
{
    #region Variables

    private static bool isPaused;
    private static bool isGameOver;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        isPaused = false;
        isGameOver = false;
        print("start");
    }

    #endregion


    #region Public Methods

    // ReSharper disable Unity.PerformanceAnalysis
    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("End Game");
        Pause();
        UiManager.Instance.CreateGameOverView();
    }

    public void DelayedEndGame(float duration)
    {
        Invoke(nameof(EndGame), duration);
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;

        //TODO: make separate script(?) for magnet disable
        FindObjectOfType<FuelManager>().DisableMagnets();
        if (!isGameOver) UiManager.Instance.CreatePauseView();
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        FindObjectOfType<FuelManager>().EnableMagnets();

        if (isGameOver)
        {
            SceneLoader.Instance.ReloadCurrentScene();
            isGameOver = false;
        }
        else
        {
            UiManager.Instance.DestroyPauseView();
            FindObjectOfType<Ball>().TurnTrailOff();
        }
    }

    #endregion
}
