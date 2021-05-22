using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Image progressBarImage;

    [SerializeField] private Sprite fullFuelSprite;
    [SerializeField] private Sprite mediumFuelSprite;
    [SerializeField] private Sprite lowFuelSprite;

    private float lowFuelLevel = .3f;
    private float MediumFuelLevel = .6f;

    #endregion


    #region Private methods

    public void SetFuelLevel(float value)
    {
        progressBarImage.transform.localScale = new Vector3(value, 1, 1);
        var currentSprite = progressBarImage.sprite;

        if (value > MediumFuelLevel && currentSprite != fullFuelSprite)
        {
            progressBarImage.sprite = fullFuelSprite;
        }
        else if (value < MediumFuelLevel && value > lowFuelLevel && currentSprite != mediumFuelSprite)
        {
            progressBarImage.sprite = mediumFuelSprite;
        }
        else if (value < lowFuelLevel && currentSprite != lowFuelSprite)
        {
            progressBarImage.sprite = lowFuelSprite;
        }
    }

    //TODO: make pause menu

    #endregion
}
