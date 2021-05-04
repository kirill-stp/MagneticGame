using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMagnet : MonoBehaviour
{
    #region Variables

    [SerializeField] private float xForceValue;
    [SerializeField] private float yForceValue;
    [SerializeField] private Ball ball;
    [SerializeField] private BoxCollider2D boxCollider;

    #endregion

    #region Unity lifecycle

    private void OnMouseDrag()
    {
        print(nameof(OnMouseDrag));
        ball.ToBoxMagnet(transform, boxCollider, xForceValue, yForceValue);
    }

    #endregion
}
