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
        
        //TODO: add view with some score
        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        fuelManager.OnFuelEnd += sceneLoader.LoadLoseScene;
    }

    private void OnDestroy()
    {
        endHole.OnHoleEnter -= sceneLoader.LoadNextScene;
        fuelManager.OnFuelEnd -= sceneLoader.LoadLoseScene;
    }

    #endregion
}
