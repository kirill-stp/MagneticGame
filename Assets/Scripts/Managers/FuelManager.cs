using System;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private float maxFuel;
    private float currentFuel;
    
    [SerializeField] private Magnet[] magnets;

    private UiManager uiManager;

    private static bool isCheatOn;
    
    #endregion

    #region Properties

    public float CurrentFuel
    {
        get => currentFuel;
    }

    #endregion

    #region Events

    public event Action OnFuelEnd;
    //TODO: add cheat code that cap fuel at max level

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        currentFuel = maxFuel;

        isCheatOn = false;
        
        uiManager = FindObjectOfType<UiManager>();

        AddToMagnets();
    }

    private void OnDestroy()
    {
        RemoveFromMagnets();
    }

    #endregion

    #region Public methods

    private void ConsumeFuel(float value)
    {
        if (isCheatOn) return;
        currentFuel -= value;
        uiManager.SetFuelLevel(currentFuel/maxFuel);
        CheckFuelLevel();
    }

    public static void TurnCheat()
    {
        isCheatOn = !isCheatOn;
    }

    #endregion

    #region Private Methods

    private void CheckFuelLevel()
    {
        if (currentFuel <= 0)
        {
            OnFuelEnd?.Invoke();
        }
    }

    private void AddToMagnets()
    {
        foreach (var magnet in magnets)
        {
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue/100));
        }
    }

    private void RemoveFromMagnets()
    {
        foreach (var magnet in magnets)
        {
            magnet.OnMagnetDrag -= () => ConsumeFuel(Math.Abs(magnet.ForceValue/100));
        }
    }

    #endregion
}
