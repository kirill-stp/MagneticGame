using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class EndHole : MonoBehaviour
{
    #region Events

    public Action OnHoleEnter; // Why delegate?

    #endregion
    
    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHoleEnter();
    }

    #endregion
    
}
