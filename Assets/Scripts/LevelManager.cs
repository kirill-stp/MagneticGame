using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    private SceneLoader sceneLoader;
    private EndHole endHole;
    private FuelManager fuelManager;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        endHole = FindObjectOfType<EndHole>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        fuelManager = FindObjectOfType<FuelManager>();
        
        //TODO: add win scene or win view with some score and restart button
        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        fuelManager.OnFuelEnd += sceneLoader.LoadEndScene;
        //TODO: add buttons on game over scene with restart logic.
        
    }

    private void OnDestroy()
    {
        endHole.OnHoleEnter -= sceneLoader.LoadNextScene;
        fuelManager.OnFuelEnd -= sceneLoader.LoadEndScene;
    }

    #endregion
}
