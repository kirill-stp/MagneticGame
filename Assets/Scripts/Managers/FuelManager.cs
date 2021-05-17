using System;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private float maxFuel;
    private float currentFuel;
    [SerializeField] private Magnet[] magnets;
    
    private UiManager uiManager;

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
        currentFuel -= value;
        uiManager.SetFuelLevel(currentFuel/maxFuel);
        CheckFuelLevel();
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
