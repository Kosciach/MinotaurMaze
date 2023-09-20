using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanelController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject[] _panels;

    public void ChangePanel(GameObject currentPanel)
    {
        foreach (GameObject panel in _panels) panel.SetActive(false);
        currentPanel.SetActive(true);
    }
}
