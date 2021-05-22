using UnityEngine;

public class Laser : MonoBehaviour
{
    #region Variables

    [Header(nameof(Laser))]
    [SerializeField] private GameObject destroyParticlePrefab;
    

    #endregion


    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(destroyParticlePrefab,other.transform.position,new Quaternion());
        Destroy(other.gameObject);
        
    }

    #endregion
}
