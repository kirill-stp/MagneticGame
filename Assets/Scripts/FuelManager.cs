using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private float maxFuel;
    private float currentFuel;
    
    private UiManager uiManager;

    #endregion

    #region Events

    public Action OnFuelEnd; // Why delegate?
    //TODO: add cheat code that cap fuel at max lelvel

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        currentFuel = maxFuel;
        
        uiManager = FindObjectOfType<UiManager>();

        AddToMagnets();
    }

    #endregion

    #region Public methods

    public void ConsumeFuel(float value)
    {
        currentFuel -= value;
        uiManager.SetFuelLevel(currentFuel);
        CheckFuelLevel();
    }

    #endregion

    #region Private Methods

    private void CheckFuelLevel()
    {
        if (currentFuel <= 0)
        {
            OnFuelEnd();
            OnFuelEnd = null; // This is ok, but there is better solution
        }
    }

    private void AddToMagnets()
    {
        var ballMagnets = FindObjectsOfType<BallMagnet>();
        var boxMagnets = FindObjectsOfType<BoxMagnet>();
        
        foreach (var magnet in ballMagnets)
        {
            // Instead of writing ForceValue / 100 u can write ForceValue * 0.01f. Multiplication faster then division.
            // Here u add lambda to delegate and dont remove it. It leads to memory leaks and bugs.
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue/100));
        }

        foreach (var magnet in boxMagnets)
        {
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue/100));
        }
    }

    #endregion
}
