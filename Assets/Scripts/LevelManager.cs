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
        
        // Same here. Subscription without unsubscription
        // U dont handle last scene so u have an error in 3rd scene. Try add win scene or win view with some score
        // and restart button
        endHole.OnHoleEnter += sceneLoader.LoadNextScene;
        fuelManager.OnFuelEnd += () => sceneLoader.LoadScene(0);
        // Try add buttons on game over scene with restart logic.
    }
}
