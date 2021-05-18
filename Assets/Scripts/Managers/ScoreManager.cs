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
        //TODO: unsubscription
        SceneLoader.OnStartSceneLoaded += ResetFuel;
        fuelSaved = 0;
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
}
