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
        // ???
        var scoreManagers = FindObjectsOfType<ScoreManager>();
        print($"managers found : {scoreManagers.Length}");
        
        print($"score manager fuel: {scoreManager.fuelSaved}");
        
        //TODO: add view with some score
        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        endHole.OnHoleEnter += AddFuelToScore;
        fuelManager.OnFuelEnd += sceneLoader.LoadLoseScene;
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
