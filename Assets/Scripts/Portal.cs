using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    #region Variables

    [SerializeField] private Portal pair;
    [SerializeField] private float disableTime;
    
    private bool isInteractable;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        isInteractable = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isInteractable) return;
        pair.Disable(disableTime);
        other.transform.position = pair.transform.position;
    }

    #endregion


    #region Public Methods

    public void Disable(float duration)
    {
        isInteractable = false;
        Invoke(nameof(Enable), duration);
    }
    
    #endregion


    #region Private Methods

    private void Enable()
    {
        isInteractable = true;
    }
    
    #endregion
}
