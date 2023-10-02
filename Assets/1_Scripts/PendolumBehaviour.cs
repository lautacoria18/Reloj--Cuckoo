using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PendolumBehaviour : MonoBehaviour
{
    [SerializeField] float maxAngle;


    private void Update()
    {
        DateTime now = DateTime.Now;
        string formattedSeconds = now.ToString("ss.ffffff");

        float secondsWithDecimals;

        float.TryParse(formattedSeconds, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out secondsWithDecimals);

        float angle = maxAngle * Mathf.Sin(secondsWithDecimals * Mathf.PI);
        transform.localRotation = Quaternion.Euler(0, 0, angle);

  
    }
}
