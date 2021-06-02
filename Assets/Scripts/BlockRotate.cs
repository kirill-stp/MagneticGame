using UnityEngine;

public class BlockRotate : MonoBehaviour
{
    #region Variales

    [SerializeField] private float rotateAngle;

    #endregion


    #region Unity lifecycle

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateAngle);
    }

    #endregion
}
