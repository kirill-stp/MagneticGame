using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    #region Events

    public event Action OnFKeyPressed;
    public event Action OnEscKeyPressed;

    #endregion
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnFKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscKeyPressed?.Invoke();
        }
    }
}
