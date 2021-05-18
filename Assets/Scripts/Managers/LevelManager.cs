using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    private SceneLoader sceneLoader;
    private EndHole endHole;
    private FuelManager fuelManager;
    private ScoreManager scoreManager;
    private InputManager inputManager;

    private bool isPaused;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        isPaused = false;
        
        // DI
        endHole = FindObjectOfType<EndHole>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        fuelManager = FindObjectOfType<FuelManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        inputManager = FindObjectOfType<InputManager>();

        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        endHole.OnHoleEnter += AddFuelToScore;
        fuelManager.OnFuelEnd += sceneLoader.LoadLoseScene;
        
        inputManager.OnFKeyPressed += FuelManager.TurnCheat;
        inputManager.OnEscKeyPressed += TogglePause;
    }

    private void OnDestroy()
    {
        endHole.OnHoleEnter -= sceneLoader.LoadNextScene;
        endHole.OnHoleEnter -= AddFuelToScore;
        fuelManager.OnFuelEnd -= sceneLoader.LoadLoseScene;
        inputManager.OnFKeyPressed -= FuelManager.TurnCheat;
        inputManager.OnEscKeyPressed -= TogglePause;
    }

    #endregion

     #region Private methods

    private void AddFuelToScore()
    {
        var score = fuelManager.CurrentFuel;
        scoreManager.AddFuelSaved(score);
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    #endregion
}
