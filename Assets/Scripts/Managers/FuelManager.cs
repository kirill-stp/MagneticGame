using System;
using Unity.Mathematics;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private float maxFuel;
    private float currentFuel;

    [SerializeField] private Magnet[] magnets;

    private UiManager uiManager;

    private static bool isCheatOn;
    //TODO: add separate class for cheatcode managment

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
    }

    private void OnEnable()
    {
        AddToMagnets();
    }

    private void OnDisable()
    {
        RemoveFromMagnets();
    }

    #endregion


    #region Public methods

    private void ConsumeFuel(float value)
    {
        if (isCheatOn) return;

        currentFuel -= value;
        currentFuel = math.clamp(currentFuel,0,maxFuel);
        uiManager.SetFuelLevel(currentFuel / maxFuel);
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
            magnet.OnDragged += Magnet_OnDragged;
        }
    }

    private void RemoveFromMagnets()
    {
        foreach (var magnet in magnets)
        {
            magnet.OnDragged -= Magnet_OnDragged;
        }
    }

    #endregion


    #region Event handlers

    private void Magnet_OnDragged(Magnet magnet)
    {
        ConsumeFuel(Math.Abs(magnet.ForceValue / 100));
    }

    #endregion
}
