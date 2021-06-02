using System;
using UnityEngine;

public abstract class Magnet : MonoBehaviour
{
    #region Variables

    [Header(nameof(Magnet))]
    [SerializeField] protected float forceValue;
    [SerializeField] private Ball ball;

    private bool isInteractable;

    #endregion


    #region Properties

    public float ForceValue => forceValue;

    #endregion


    #region Events

    public event Action<Magnet> OnDragged;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        Enable();
    }

    private void OnMouseDrag()
    {
        if (!ball || !isInteractable) return;

        ApplyForce(ball);
        OnDragged?.Invoke(this);
    }

    private void OnMouseDown()
    {
        if (!ball || !isInteractable) return;

        ball.TurnTrailOn(forceValue);
    }

    private void OnMouseUp()
    {
        if (!ball || !isInteractable) return;

        ball.TurnTrailOff();
    }

    #endregion


    #region Public Methods

    public void Disable()
    {
        isInteractable = false;
    }

    public void Enable()
    {
        isInteractable = true;
    }

    #endregion


    #region Private methods

    protected abstract void ApplyForce(Ball ball);

    #endregion
}
