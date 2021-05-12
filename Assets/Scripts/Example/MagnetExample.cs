using UnityEngine;

public abstract class MagnetExample : MonoBehaviour
{
    #region Variables

    [Header(nameof(MagnetExample))]
    [SerializeField] protected float forceValue;
    [SerializeField] private Ball ball;

    #endregion


    #region Properties

    public float ForceValue => forceValue;

    #endregion


    #region Unity lifecycle

    private void OnMouseDrag()
    {
        ApplyForce(ball);
    }

    #endregion


    #region Private methods

    protected abstract void ApplyForce(Ball ball);

    #endregion
}
