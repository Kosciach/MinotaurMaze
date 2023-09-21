using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScenesController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GoToMainMenu());
    }

    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(2);

        SceneFaderController.Instance.FadeAndChangeScene("MainMenuScene");
    }
}
