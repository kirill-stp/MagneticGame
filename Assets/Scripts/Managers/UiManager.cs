using System;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : SingletonMonoBehaviour<UiManager>
{
    #region Variables

    [Header(nameof(UiManager))]
    [Header("Progress Bar Image")]
    [SerializeField] private Image progressBarImage;
    [SerializeField] private string progressBarImageTag;

    [SerializeField] private Sprite fullFuelSprite;
    [SerializeField] private Sprite mediumFuelSprite;
    [SerializeField] private Sprite lowFuelSprite;
    
    [SerializeField] private GameObject gameOverViewPrefab;
    [SerializeField] private GameObject pauseViewPrefab;

    private GameObject pauseView;
    private GameObject gameOverView;

    private float lowFuelLevel = .3f;
    private float MediumFuelLevel = .6f;

    #endregion


    #region private methods

    private void FindImage()
    {
        progressBarImage = GameObject.FindGameObjectWithTag(progressBarImageTag).GetComponent<Image>();
    }

    #endregion


    #region Public methods

    public void SetFuelLevel(float value)
    {
        if (!progressBarImage) FindImage();

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

    public void CreateGameOverView()
    {
         gameOverView = Instantiate(gameOverViewPrefab);
    }

    public void CreatePauseView()
    {
        if (gameOverView) return;
        pauseView = Instantiate(pauseViewPrefab);
    }

    public void DestroyPauseView()
    {
        Destroy(pauseView);
    }

    #endregion
}
