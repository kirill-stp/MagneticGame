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
    }

    private void OnEnable()
    {
        endHole = FindObjectOfType<EndHole>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        fuelManager = FindObjectOfType<FuelManager>();
        scoreManager = ScoreManager.Instance;
        inputManager = InputManager.Instance;

        endHole.OnEntered += EndHole_OnHoleEntered;
        fuelManager.OnFuelEnd += sceneLoader.LoadLoseScene;

        inputManager.OnFKeyPressed += FuelManager.TurnCheat;
        inputManager.OnEscKeyPressed += TogglePause;
    }

    private void OnDisable()
    {
        endHole.OnEntered -= EndHole_OnHoleEntered;
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

        Time.timeScale = isPaused ? 0 : 1;
    }

    #endregion


    #region Event handlers

    private void EndHole_OnHoleEntered()
    {
        sceneLoader.LoadNextScene();
        AddFuelToScore();
    }

    #endregion
}
