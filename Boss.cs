using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        PlayBossSound();
    }

    public void PlayBossSound()
    {
        GameObject.Find("SFXManager").SendMessage("PlayBossSound");
    }
}
