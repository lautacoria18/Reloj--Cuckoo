using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List <GameObject> objectsToTurnOffNormalMode = new List<GameObject> ();
    [SerializeField] private List <GameObject> objectsToTurnOffArMode = new List<GameObject> ();


    private void Awake()
    {
        if (GameMode.instance.arMode)
        {


            for (int i = 0; i < objectsToTurnOffArMode.Count; i++)
            {
                objectsToTurnOffArMode[i].SetActive(false);

            }
            for (int i = 0; i < objectsToTurnOffNormalMode.Count; i++)
            {
      
                objectsToTurnOffNormalMode[i].SetActive(true);
            }

        }
        else {


            for (int i = 0; i < objectsToTurnOffNormalMode.Count; i++)
            {
                objectsToTurnOffNormalMode[i].SetActive(false);

            }
            for (int i = 0; i < objectsToTurnOffArMode.Count; i++)
            {
      
                objectsToTurnOffArMode[i].SetActive(true);
            }



        }
    }
}
