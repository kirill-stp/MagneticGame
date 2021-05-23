using UnityEngine;

public class PauseManager : MonoBehaviour
{
    #region Variables

    private static bool isPaused;

    #endregion


    #region Public Methods

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            UiManager.Instance.CreatePauseView();
        }
        else
        {
            Time.timeScale = 1;
            UiManager.Instance.DestroyPauseView();
        }
    }

    #endregion
}
