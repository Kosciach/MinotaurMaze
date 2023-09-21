using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : MonoBehaviour
{
    public void StartGame()
    {
        AudioController.Instance.PlaySound("ButtonClick");
        SceneFaderController.Instance.FadeAndChangeScene("MainScene");
    }
    public void ExitGame()
    {
        AudioController.Instance.PlaySound("ButtonClick");
        Application.Quit();
    }
}
