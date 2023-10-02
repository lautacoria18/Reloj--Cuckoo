using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, ObjectAnimate
{
    Animator animator;
    [HideInInspector] public bool doorOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    //Si las puertas estan abiertas, se cerraran y si estan cerradas se abriran
    public void Animate()
    {
        animator.SetBool("Open", !animator.GetBool("Open"));
        if (animator.GetBool("Open"))
        {

            doorOpen = true;

        }
        else {

            doorOpen = false;
            }
    }
}
