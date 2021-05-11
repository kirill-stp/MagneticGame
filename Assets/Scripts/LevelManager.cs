using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private SceneLoader sceneLoader;
    private EndHole endHole;
    private FuelManager fuelManager;

    private void Start()
    {
        endHole = FindObjectOfType<EndHole>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        fuelManager = FindObjectOfType<FuelManager>();
        
        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        fuelManager.OnFuelEnd += () => sceneLoader.LoadScene(0);
    }
}
