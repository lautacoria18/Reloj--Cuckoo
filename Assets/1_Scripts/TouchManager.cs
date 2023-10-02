using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask mask;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, mask)) {

                string colliderName = hit.collider.name;

                switch (colliderName)
                {

                    case "Bird":
                        hit.collider.gameObject.GetComponent<BirdBehaviour>().Animate();
                        break;
                    case "LeftDoor":

                        hit.collider.gameObject.transform.parent.parent.GetComponent<DoorBehaviour>().Animate();
                        break;
                    case "RightDoor":

                        hit.collider.gameObject.transform.parent.parent.GetComponent<DoorBehaviour>().Animate();
                        break;
                    default:
                        break;
                }
                
            }
        
        
        }
    }
}
