using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{


    //Carga la escena de eleccion de modo
    public void BackToMenu() {


        SceneManager.LoadScene("StartScene");
    }
    //Carga la escena principal del reloj
    public void LoadMainScene(bool ARMode) {


        GameMode.instance.SetMode(ARMode);
        SceneManager.LoadScene("MainScene");

    }
}
