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

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        currentFuel = maxFuel;

        isCheatOn = false;

        uiManager = FindObjectOfType<UiManager>();

        // In OnEnable
        AddToMagnets();
    }

    private void OnDestroy()
    {
        // In OnDisable
        RemoveFromMagnets();
    }

    #endregion


    #region Public methods

    private void ConsumeFuel(float value)
    {
        if (isCheatOn) return;

        // One empty line before and after if for more readability 

        currentFuel -= value; // I would use clamp here to defend 'currentFuel' become negative
        uiManager.SetFuelLevel(currentFuel / maxFuel);
        CheckFuelLevel();
    }

    public static void TurnCheat()
    {
        // I would create separate class for cheats that handle all cheats and do logic
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
            // Super bad to use anonymous delegate here cuz u cant unsubscribe 
            // Should use this instead
            // magnet.OnMagnetDrag += Magnet_OnMagnetDrag;
            // in this case u create class method and u can get reference for it
            
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue / 100));
        }
    }

    private void RemoveFromMagnets()
    {
        foreach (var magnet in magnets)
        {
            magnet.OnMagnetDrag -= () => ConsumeFuel(Math.Abs(magnet.ForceValue / 100));
            
            // magnet.OnMagnetDrag -= Magnet_OnMagnetDrag;
        }
    }

    #endregion


    #region Event handlers

    private void Magnet_OnMagnetDrag(Magnet magnet)
    {
        // ConsumeFuel(Math.Abs(magnet.ForceValue / 100));
    }

    #endregion
}
