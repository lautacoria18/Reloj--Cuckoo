using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{



    public void BackToMenu() {


        SceneManager.LoadScene("StartScene");
    }

    public void LoadMainScene(bool ARMode) {


        GameMode.instance.SetMode(ARMode);
        SceneManager.LoadScene("MainScene");

    }
}
