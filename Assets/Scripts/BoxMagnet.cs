using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMagnet : MonoBehaviour
{
    #region Variables

    [SerializeField] private float forceValue;
    public float ForceValue => forceValue;

    [SerializeField] private Ball ball;
    [SerializeField] private BoxCollider2D boxCollider;

    #endregion

    #region Events

    public Action OnMagnetDrag;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        OnMagnetDrag += AttractBall;
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