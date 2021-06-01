using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    #region Variables

    private static bool isPaused;
    private static bool isGameOver;

    #endregion


    #region Public Methods

    // ReSharper disable Unity.PerformanceAnalysis
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (!isPaused)
        {
            Resume();
            if (isGameOver) SceneLoader.Instance.ReloadCurrentScene();
        }
        else
        {
            Pause();
        }
    }

    public void EndGame()
    {
        TogglePause();
        isGameOver = true;
        UiManager.Instance.CreateGameOverView();
    }

    private void Pause()
    {
        Time.timeScale = 0;

        //TODO: make separate script(?) for magnet disable
        FindObjectOfType<FuelManager>().DisableMagnets();
        UiManager.Instance.CreatePauseView();
    }

    private void Resume()
    {
        Time.timeScale = 1;
        FindObjectOfType<FuelManager>().EnableMagnets();
        UiManager.Instance.DestroyPauseView();
        FindObjectOfType<Ball>().TurnTrailOff();
    }

    #endregion
}
