using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
