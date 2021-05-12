using System;
using System.Collections; // Should delete unused directories
using System.Collections.Generic;
using UnityEngine;

// This is the same class as BallMagnet. Here need one base class Magnet and then use inheritance.
public class BoxMagnet : MonoBehaviour
{
    #region Variables

    [SerializeField] private float forceValue;
    public float ForceValue => forceValue; // This is property and should be in Properties region

    [SerializeField] private Ball ball;
    [SerializeField] private BoxCollider2D boxCollider;

    #endregion

    #region Events

    public Action OnMagnetDrag; // This is delegate not event. Why do u use delegates?

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        OnMagnetDrag += AttractBall; // This is useless code. U can just call AttractBall in OnMouseDrag method
    }

    private void OnMouseDrag()
    {
        OnMagnetDrag();
    }

    #endregion

    #region Private methods

    private void AttractBall()
    {
        ball.ToBoxMagnet(transform, boxCollider, forceValue);
    }

    #endregion
}