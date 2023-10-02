using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BirdBehaviour : MonoBehaviour ,ObjectAnimate
{
    Animator animator;
    DoorBehaviour doorBehaviour;


    private void Start()
    {
        animator = GetComponent<Animator>();
        doorBehaviour = FindObjectOfType<DoorBehaviour>();
    }
    //En esta funcion la animacion junto con el sonido solo se ejecutaran si la animacion no se esta ejecutando y si las puertas de la casita estan abiertas
    public void  Animate()
    {
        bool animacionActiva = animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
        if (!animacionActiva && doorBehaviour.doorOpen)
        {

            animator.SetTrigger("Dance");
            GetComponent<AudioSource>().Play();

        }
    }
}
