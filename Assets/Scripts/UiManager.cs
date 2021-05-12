using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Schema; // Remove unused directories
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    #region Variables

    [SerializeField] private Text fuelText;

    #endregion

    #region Private methods

    //TODO: make progress bar
    public void SetFuelLevel(float value)
    {
        // This u can just use .ToString() or dont use it at all
        // fuelText.text = $"Power:\n{Math.Round(value,2)}";

        fuelText.text = $"Power:\n{Math.Round(value,2).ToString(CultureInfo.InvariantCulture)}";
    }
    
    //TODO: make pause menu

    #endregion
}
