using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMagnet : MonoBehaviour
{
    #region Variables

    [SerializeField]private float forceValue;
    [SerializeField] private Ball ball;

    #endregion

    #region Unity lifecycle

    private void OnMouseDrag()
    {
        print(nameof(OnMouseDrag));
        ball.ToBallMagnet(transform,forceValue);
    }

    #endregion
}
