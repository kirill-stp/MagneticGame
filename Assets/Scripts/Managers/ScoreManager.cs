using System;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    #region Variables

    private float fuelSaved;

    #endregion


    #region Properties

    public float FuelSaved => fuelSaved;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        fuelSaved = 0;
    }

    private void OnEnable()
    {
        SceneLoader.OnStartSceneLoaded += SceneLoader_OnStartSceneLoaded;
        
    }

    private void OnDisable()
    {
        SceneLoader.OnStartSceneLoaded -= SceneLoader_OnStartSceneLoaded;
    }

    #endregion


    #region Public methods

    public void AddFuelSaved(float value)
    {
        fuelSaved += value;
    }

    public void ResetFuel()
    {
        print("Fuel reseted");
        fuelSaved = 0;
    }

    #endregion


    #region Event handlers

    private void SceneLoader_OnStartSceneLoaded()
    {
        ResetFuel();
    }

    #endregion
}
