using System;
using Managers;
using Unity.Mathematics;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private float maxFuel;
    private float currentFuel;

    [SerializeField] private Magnet[] magnets;

    private UiManager uiManager;
    private CheatCodeManager cheatCodeManager;

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
    }

    private void OnEnable()
    {
        uiManager = FindObjectOfType<UiManager>();
        cheatCodeManager = CheatCodeManager.Instance;
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
        if (cheatCodeManager.IsFuelCheatOn) return;

        currentFuel -= value;
        currentFuel = math.clamp(currentFuel, 0, maxFuel);
        uiManager.SetFuelLevel(currentFuel / maxFuel);
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
