using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : MonoBehaviour
{
    public void StartGame()
    {
        FaderController.Instance.FadeAndChangeScene("MainScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
