using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    #region Variables
    
    private ScoreManager scoreManager;
    [SerializeField] private Text scoreText;
    
    
    #endregion

    #region Unity lifecycle

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        int score = (int) Math.Round(scoreManager.FuelSaved);
        scoreText.text = $"SCORE:\n{score}";

    }

    #endregion

}
