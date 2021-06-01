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

        currentFuel -= value * Time.timeScale;
        currentFuel = math.clamp(currentFuel, 0, maxFuel);
        UiManager.Instance.SetFuelLevel(currentFuel / maxFuel);
        CheckFuelLevel();
    }

    #endregion


    #region Private Methods

    private void CheckFuelLevel()
    {
        if (currentFuel <= 0)
        {
            OnFuelEnd?.Invoke();
            DisableMagnets();
            gameObject.SetActive(false);
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

    public void DisableMagnets()
    {
        foreach (var magnet in magnets)
        {
            magnet.Disable();
        }
    }
    
    public void EnableMagnets()
    {
        foreach (var magnet in magnets)
        {
            magnet.Enable();
        }
    }

    #endregion


    #region Event handlers

    private void Magnet_OnDragged(Magnet magnet)
    {
        ConsumeFuel(Math.Abs(magnet.ForceValue / 300));
    }

    #endregion
}
