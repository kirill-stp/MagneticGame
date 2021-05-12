using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;

    #endregion
    
    #region Public Methods
    
    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    #endregion
}
