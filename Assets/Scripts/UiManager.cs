using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    #region Variables

    [SerializeField] private Text fuelText;

    #endregion

    #region Public methods

    public void SetFuelLevel(float value)
    {
        fuelText.text = $"Power: {value.ToString(CultureInfo.InvariantCulture)}";
    }

    #endregion
}
