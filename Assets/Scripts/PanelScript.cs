using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
    public GameObject help;
    public GameObject menu;
    public void OnHelp()
    {
        help.SetActive(true);
    }

    public void OffHelp()
    {
        help.SetActive(false);
    }

    public void OnMenu()
    {
        menu.SetActive(true);
    }

    public void OffMenu()
    {
        menu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
