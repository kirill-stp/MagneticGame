using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;

    #endregion
    
    #region Public Methods

    public void ToBallMagnet(Transform magnet, float forceValue)
    {
        rb.AddForce((Vector2)(magnet.position - transform.position ) * forceValue);
    }

    public void ToBoxMagnet(Transform magnet, BoxCollider2D magnetBox, float forceValue)
    {
        var bounds = magnetBox.bounds;
        
        if ((bounds.min.y < transform.position.y &&
             bounds.max.y > transform.position.y) &&
            (transform.position.x < bounds.min.x || transform.position.x > bounds.max.x))
        {
            // to the left or right of the magnet
            var force = (magnet.position.x - transform.position.x) * forceValue;
            var horizontalForce = new Vector2(force, 0);
            rb.AddForce(horizontalForce);
        }
        else if ((bounds.min.x < transform.position.x &&
                  bounds.max.x > transform.position.x) &&
                 (transform.position.y < bounds.min.y || transform.position.y > bounds.max.y))
        {
            // to the top or bottom of the magnet
            var force = (magnet.position.y - transform.position.y) * forceValue;
            var verticalForce = new Vector2(0, force);
            rb.AddForce(verticalForce);
        }

    }

    #endregion
}
