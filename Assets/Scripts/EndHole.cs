using System;
using UnityEngine;

public class EndHole : MonoBehaviour
{
    #region Events

    public event Action OnHoleEnter;

    #endregion
    
    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHoleEnter?.Invoke();
    }

    #endregion
    
}
