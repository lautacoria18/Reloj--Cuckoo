using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleBehaviour : MonoBehaviour
{
    public enum Type { Seconds, Minutes, Hours };

    [SerializeField] Type valueType; 
    [SerializeField] private float min, max; 
    Transform needle;
    float angMin = 0;
    float angMax = 360;
    float oldZValue;

    private void Start()
    {
        needle = transform;
    }

    void Update()
    {
        UpdateNeedle();
    }

    //Esta funcion sirve para actualizar la rotacion de la aguja en base a la hora actual dentro de un rango de 360 graods dependiendo que tipo de aguja sea.
    private void UpdateNeedle()
    {

        var date = DateTime.Now;
        float hour = ((date.Hour + 11) % 12) + 1;
        float minute = date.Minute;
        float seconds = date.Second;
        float valorNormalizado = 0;

        switch (valueType)
        {
            case Type.Seconds:
                valorNormalizado = Mathf.InverseLerp(min, max, seconds);
                break;
            case Type.Minutes:
                valorNormalizado = Mathf.InverseLerp(min, max, minute);
                break;
            case Type.Hours:
                valorNormalizado = Mathf.InverseLerp(min, max, hour);
                break;
            default:
                break;
        }

        float angle = Mathf.Lerp(angMin, angMax, valorNormalizado);
        needle.localRotation = Quaternion.Euler(0f, 0f, angle);


        float zValue = needle.transform.localRotation.z;

        if (zValue != oldZValue)
        {

            GetComponent<AudioSource>().Play();
        }
        oldZValue = zValue;
    }
}
