using System;
using UnityEngine;

public class EndHole : MonoBehaviour
{
    #region Events

    // Nice name for event is OnEntered, cuz the name of script already contains name 'Hole'. And use past time plz
    public event Action OnHoleEnter;

    #endregion


    // 2 empty spaces between regions
    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHoleEnter?.Invoke();
    }

    #endregion
}
