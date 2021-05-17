using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    #region Variables

    public float fuelSaved;

    #endregion

    #region Properties

    public float FuelSaved => fuelSaved;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        print("ScoreManager START is called");
        fuelSaved = 0;
    }

    #endregion
    
    #region Public methods

    public void AddFuelSaved(float value)
    {
        this.fuelSaved += value;
        print($"new fuel :{fuelSaved.ToString()}");
    }

    #endregion
}
