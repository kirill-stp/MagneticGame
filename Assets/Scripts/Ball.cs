using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;

    #endregion
    
    #region Public Methods

    // This logic better encapsulate in magnet classes
    public void ToBallMagnet(Transform magnet, float forceValue)
    {
        var direction = magnet.position - transform.position;
        var distance = direction.magnitude;
        var force = (Vector2)direction.normalized * forceValue / distance;
        rb.AddForce(force);
    }

    // This logic better encapsulate in magnet classes
    public void ToBoxMagnet(Transform magnet, BoxCollider2D magnetBox, float forceValue)
    {
        var bounds = magnetBox.bounds;
        Vector2 force;
        
        // to the left or right from manget
        if ((bounds.min.y < transform.position.y &&
             bounds.max.y > transform.position.y) &&
            (transform.position.x < bounds.min.x || transform.position.x > bounds.max.x))
        {
            var distance = magnet.position.x - transform.position.x;
            force = new Vector2(forceValue/distance, 0);
        }
        // top or bottom
        else if ((bounds.min.x < transform.position.x &&
                  bounds.max.x > transform.position.x) &&
                 (transform.position.y < bounds.min.y || transform.position.y > bounds.max.y))
        {
            var distance = magnet.position.y - transform.position.y;
            force = new Vector2(0,forceValue/distance);
        }
        else return; // return should be on new line for better readability 
        
        rb.AddForce(force);
    }

    // For Example
    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    #endregion
}
