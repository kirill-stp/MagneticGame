using System;
using Managers;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    private SceneLoader sceneLoader;
    private EndHole endHole;
    private FuelManager fuelManager;
    private ScoreManager scoreManager;
    private InputManager inputManager;
    private CheatCodeManager cheatCodeManager;

    private bool isPaused;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        FindObjects();
    }

    private void OnEnable()
    {
        endHole.OnEntered += EndHole_OnHoleEntered;
        fuelManager.OnFuelEnd += UiManager.Instance.CreateGameOverView;

        inputManager.OnFKeyPressed += cheatCodeManager.TurnFuelCheat;
        inputManager.OnEscKeyPressed += TogglePause;
    }

    private void Start()
    {
        isPaused = false;
    }
    
    private void OnDisable()
    {
        endHole.OnEntered -= EndHole_OnHoleEntered;
        fuelManager.OnFuelEnd -= UiManager.Instance.CreateGameOverView;
        inputManager.OnFKeyPressed -= cheatCodeManager.TurnFuelCheat;
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

    private void FindObjects()
    {
        endHole = FindObjectOfType<EndHole>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        fuelManager = FindObjectOfType<FuelManager>();
        scoreManager = ScoreManager.Instance;
        inputManager = InputManager.Instance;
        cheatCodeManager = CheatCodeManager.Instance;
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
