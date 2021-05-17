using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    private SceneLoader sceneLoader;
    private EndHole endHole;
    private FuelManager fuelManager;
    private ScoreManager scoreManager;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        // DI
        endHole = FindObjectOfType<EndHole>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        fuelManager = FindObjectOfType<FuelManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        endHole.OnHoleEnter += AddFuelToScore;
        fuelManager.OnFuelEnd += sceneLoader.LoadLoseScene;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FuelManager.TurnCheat();
        }
    }

    private void OnDestroy()
    {
        endHole.OnHoleEnter -= sceneLoader.LoadNextScene;
        endHole.OnHoleEnter -= AddFuelToScore;
        fuelManager.OnFuelEnd -= sceneLoader.LoadLoseScene;
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
