using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        GameObject.Find("SFXManager").SendMessage("PlayTouchSound");
        SceneManager.LoadScene("GamePlay");
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
