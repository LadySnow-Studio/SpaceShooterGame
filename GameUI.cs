using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject PanelMenu, PanelRead;

    public void PressStart()
    {
        GameObject.Find("SFXManager").SendMessage("PlayTouchSound");
        SceneManager.LoadScene("GamePlay");
    }

    public void ShowReadPanel()
    {
        GameObject.Find("SFXManager").SendMessage("PlayChianSound");
        PanelMenu.SetActive(false);
        PanelRead.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        GameObject.Find("SFXManager").SendMessage("PlayTouchSound");
        PanelMenu.SetActive(true);
        PanelRead.SetActive(false);
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
