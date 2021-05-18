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
        scoreManager = ScoreManager.Instance; // U can use singleton benefits here. This type of injection is nice for singleton
        sceneLoader = SceneLoader.Instance;
        
        fuelManager = FindObjectOfType<FuelManager>();
        endHole = FindObjectOfType<EndHole>();
        inputManager = FindObjectOfType<InputManager>();

        
        // Subscriptions and unsubscription is better do in OnEnable and OnDisable
        // Cuz when ur game object become inactive he continue to handle events in ur case
        
        // And better to use separate methods for event like EndHole_OnHoleEnter
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
        Time.timeScale = isPaused ? 0 : 1; // Use this type of operator where possible 
    }

    #endregion
}
