using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMagnet : Magnet
{
    #region Variables

    [Header(nameof(BoxMagnet))]
    [SerializeField] private BoxCollider2D boxCollider;

    #endregion


    #region Private methods

    protected override void ApplyForce(Ball ball)
    {
        var magnetTransform = transform;
        var bounds = boxCollider.bounds;
        var ballTransform = ball.transform;
        var ballPosition = ballTransform.position;

        Vector2 force;

        // to the left or right from manget
        if ((bounds.min.y < ballPosition.y && bounds.max.y > ballPosition.y) &&
            (ballPosition.x < bounds.min.x || ballPosition.x > bounds.max.x))
        {
            var distance = magnetTransform.position.x - ballPosition.x;
            force = new Vector2(forceValue / distance, 0);
        }

        // top or bottom
        else if ((bounds.min.x < ballPosition.x && bounds.max.x > ballPosition.x) &&
            (ballPosition.y < bounds.min.y || ballPosition.y > bounds.max.y))
        {
            var distance = magnetTransform.position.y - ballPosition.y;
            force = new Vector2(0, forceValue / distance);
        }
        else
            return;

        ball.AddForce(force);
    }

    #endregion
}
