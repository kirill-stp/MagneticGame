using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMagnet : MonoBehaviour // Copy\paste class
{
    #region Variables

    [SerializeField] private float forceValue;
    public float ForceValue => forceValue;
    [SerializeField] private Ball ball;

    #endregion

    #region Events

    public Action OnMagnetDrag;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        OnMagnetDrag += AttractBall;
    }

    private void AttractBall()
    {
        ball.ToBallMagnet(transform, forceValue);
    }

    private void OnMouseDrag()
    {
        OnMagnetDrag();
    }

    #endregion
}