using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class EndHole : MonoBehaviour
{
    #region Unity lifecycle

    [SerializeField]private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        sceneLoader.LoadNextScene();
    }

    #endregion
}
