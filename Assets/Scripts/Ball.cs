using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private Gradient positiveTrail;
    [SerializeField] private Gradient negativeTrail;

    #endregion
    
    #region Public Methods
    
    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void TurnTrailOn(float forceValue)
    {
        if (forceValue > 0)
        {
            trailRenderer.colorGradient = positiveTrail;
        }
        else
        {
            trailRenderer.colorGradient = negativeTrail;
        }

        trailRenderer.emitting = true;
    }

    public void TurnTrailOff()
    {
        trailRenderer.emitting = false;
    }

    #endregion
}
