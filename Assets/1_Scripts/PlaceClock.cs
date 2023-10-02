using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.OpenXR.Input;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using Pose = UnityEngine.Pose;

[RequireComponent(requiredComponent:typeof(ARRaycastManager), requiredComponent2:typeof(ARPlaneManager)) ]
public class PlaceClock : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    GameObject Clock;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List <ARRaycastHit> hits = new List<ARRaycastHit> ();


    public Camera arCamera;
    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();

    }


    
    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    //La primera vez que se ejecute esta funcion instanciara el reloj donde el usuario toque en el plano detectado, a partir de la segunda vez el reloj sera cambiado de posicion donde toque el usuario
    void FingerDown(EnhancedTouch.Finger finger) {

        if (finger.index != 0) return;

        if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon)){ 
        foreach(ARRaycastHit hit in hits)
            {
                
              
                    Vector3 position = hits[0].pose.position;
                    Quaternion rotation = Quaternion.LookRotation(arCamera.transform.forward * -1);


                    if (GameObject.Find("Clock(Clone)"))
                    {
                        Clock.transform.position = position;
                        Clock.transform.rotation = rotation;
                    }
                    else
                    {
                        Clock = Instantiate(prefab, position, rotation);
                    }           
            }
        }
    }
}
