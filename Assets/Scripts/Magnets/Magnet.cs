using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magnet : MonoBehaviour
{
    #region Variables

    [Header(nameof(Magnet))]
    [SerializeField] protected float forceValue;
    [SerializeField] private Ball ball;

    #endregion

    #region Properties

    public float ForceValue => forceValue;

    #endregion

    #region Events

    public event Action OnMagnetDrag;

    #endregion

    #region Unity lifecycle

    private void OnMouseDrag()
    {
        ApplyForce(ball);
        OnMagnetDrag?.Invoke();
    }

    #endregion

    #region Private methods

    protected abstract void ApplyForce(Ball ball);

    #endregion
}
