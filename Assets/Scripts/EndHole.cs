using System;
using UnityEngine;

public class EndHole : MonoBehaviour
{
    #region Events

    public event Action OnEntered;

    #endregion


    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnEntered?.Invoke();
    }

    #endregion
}
