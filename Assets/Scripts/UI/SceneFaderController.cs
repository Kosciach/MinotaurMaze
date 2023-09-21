using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class SceneFaderController : MonoBehaviour
{
    private static SceneFaderController _instance; public static SceneFaderController Instance { get { return _instance; } }
    private CanvasGroup _canvasGroup;



    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        LeanTween.alphaCanvas(_canvasGroup, 0, 1);
    }


    public void FadeAndChangeScene(string scene)
    {
        LeanTween.alphaCanvas(_canvasGroup, 1, 1).setOnComplete(() =>
        {
            SceneManager.LoadScene(scene);
        });
    }
}
