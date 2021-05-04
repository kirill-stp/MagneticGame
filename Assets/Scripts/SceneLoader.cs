using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Unity lifecycle

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    #endregion
    
    #region Public methods

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}
