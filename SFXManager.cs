using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip BtnSound, ChianSound, PlayerFireSound, EnemyFireSound, BombSound, BossSound, DropItem, RecievedItem;
    public GameObject SfxPlayerPrefab;

    public void PlayTouchSound()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = BtnSound;
    }

    public void PlayChianSound()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = ChianSound;
    }

    public void PlayPlayerFireSound()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = PlayerFireSound;
    }

    public void PlayEnemyFireSound()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = EnemyFireSound;
    }

    public void PlayBombSound()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = BombSound;
    }

    public void PlayBossSound()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = BossSound;
    }

    public void PlayDropItem()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = DropItem;
    }

    public void PlayRecievedItem()
    {
        GameObject thisSfx = Instantiate(SfxPlayerPrefab);
        thisSfx.GetComponent<SFXPlayer>().clip = RecievedItem;
    }

}

