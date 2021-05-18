using System;
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

    // Use name 'OnDragged' and type 'Action<Magnet>'
    public event Action OnMagnetDrag;

    #endregion


    #region Unity lifecycle

    private void OnMouseDrag()
    {
        ApplyForce(ball);
        OnMagnetDrag?.Invoke();
    }

    private void OnMouseDown()
    {
        ball.TurnTrailOn(forceValue);
    }

    private void OnMouseUp()
    {
        ball.TurnTrailOff();
    }

    #endregion


    #region Private methods

    protected abstract void ApplyForce(Ball ball);

    #endregion
}
