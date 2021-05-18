using System;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Image progressBarImage;

    [SerializeField] private Sprite fullFuelSprite;
    [SerializeField] private Sprite mediumFuelSprite;
    [SerializeField] private Sprite lowFuelSprite;

    #endregion


    #region Private methods

    public void SetFuelLevel(float value)
    {
        progressBarImage.transform.localScale = new Vector3(value, 1, 1);
        var currentSprite = progressBarImage.sprite;

        // What this magic numbers are?
        // Use constants or better setup from editor.
        // Dont use hardcode where u can dont use it
        if (value > .6f && currentSprite != fullFuelSprite)
        {
            progressBarImage.sprite = fullFuelSprite;
        }
        else if (value < .6f && value > .3f && currentSprite != mediumFuelSprite)
        {
            progressBarImage.sprite = mediumFuelSprite;
        }
        else if (value < .3f && currentSprite != lowFuelSprite)
        {
            progressBarImage.sprite = lowFuelSprite;
        }
    }

    //TODO: make pause menu

    #endregion
}
