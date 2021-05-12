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

    public Action OnFuelEnd;
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
            OnFuelEnd = null;
        }
    }

    private void AddToMagnets()
    {
        var ballMagnets = FindObjectsOfType<BallMagnet>();
        var boxMagnets = FindObjectsOfType<BoxMagnet>();
        foreach (var magnet in ballMagnets)
        {
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue/100));
        }

        foreach (var magnet in boxMagnets)
        {
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue/100));
        }
    }

    #endregion
}
