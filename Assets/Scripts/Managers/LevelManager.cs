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

    #endregion

    #region Unity lifecycle

    private void Start()
    {
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
    }

    private void OnDestroy()
    {
        endHole.OnHoleEnter -= sceneLoader.LoadNextScene;
        endHole.OnHoleEnter -= AddFuelToScore;
        fuelManager.OnFuelEnd -= sceneLoader.LoadLoseScene;
        inputManager.OnFKeyPressed -= FuelManager.TurnCheat;
    }

    #endregion

     #region Private methods

    private void AddFuelToScore()
    {
        var score = fuelManager.CurrentFuel;
        scoreManager.AddFuelSaved(score);
    }

    #endregion
}
