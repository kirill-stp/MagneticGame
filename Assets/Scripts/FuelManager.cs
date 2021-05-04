using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private float maxFuel;
    private float currentFuel;
    
    private SceneLoader sceneLoader;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        currentFuel = maxFuel;
        
        sceneLoader = FindObjectOfType<SceneLoader>();
        var ballMagnets = FindObjectsOfType<BallMagnet>();
        var boxMagnets = FindObjectsOfType<BoxMagnet>();
        foreach (var magnet in ballMagnets)
        {
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue));
        }

        foreach (var magnet in boxMagnets)
        {
            magnet.OnMagnetDrag += () => ConsumeFuel(Math.Abs(magnet.ForceValue));
        }
        
    }

    #endregion

    #region Public methods

    public void ConsumeFuel(float value)
    {
        currentFuel -= value;
        print(currentFuel.ToString());
        CheckFuelLevel();
    }

    #endregion

    #region Private Methods

    private void CheckFuelLevel()
    {
        if (currentFuel <= 0)
        {
            sceneLoader.LoadScene(1);
        }
    }

    #endregion
}
