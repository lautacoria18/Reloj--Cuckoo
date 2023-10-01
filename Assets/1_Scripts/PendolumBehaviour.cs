using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PendolumBehaviour : MonoBehaviour
{
    [SerializeField] float maxAngle;


    private void Update()
    {

        string stringDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss,ffffff", CultureInfo.InvariantCulture);
        string secondsDecimal = stringDate.Substring(stringDate.Length - 9);
        float realSecondsFloat = float.Parse(secondsDecimal);


        float angle = maxAngle * Mathf.Sin(realSecondsFloat * Mathf.PI);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
