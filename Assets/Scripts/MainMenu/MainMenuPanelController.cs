using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanelController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject[] _panels;

    private void Start()
    {
        ChangePanel(_panels[0]);
    }
    public void ChangePanel(GameObject currentPanel)
    {
        AudioController.Instance.PlaySound("ButtonClick");
        foreach (GameObject panel in _panels) panel.SetActive(false);
        currentPanel.SetActive(true);
    }
}
