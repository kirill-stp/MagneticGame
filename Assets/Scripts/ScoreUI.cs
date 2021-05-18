using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    #region Variables

    [SerializeField] private Text scoreText;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        int score = (int) Math.Round(ScoreManager.Instance.FuelSaved);
        scoreText.text = $"SCORE:\n{score}";
    }

    #endregion
}
