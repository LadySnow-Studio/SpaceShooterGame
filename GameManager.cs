using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score, Boss;
    public Text ScoreText, ScoreOverText;
    public GameObject[] MonterPrefab;
    public GameObject BossPrefab, WinPanel;
    public Transform LeftSpawnPoint, RightSpawnPoint, BossSpawnPoint;
    public float MinDelaySpawn, MaxDelaySpawn;
    public float CurrentDelay;
    public bool IsTime;
    public bool IsBossDead;
    

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnMonster",0,1); //fixเวลา
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowScore();
        SpawnMonterWithDelay();

        if (Score > 1000)
        {
            IsTime = true;
        }

        if (IsBossDead)
        {
            ShowWinPanel();
        }
    }
    public void ShowScore()
    {
        ScoreText.text = "Score : " + Score.ToString(Score > 0 ? "#,###,###":"");
        ScoreOverText.text = "Score : " + Score.ToString(Score > 0 ? "#,###,###" : "");
    }
    public void SpawnMonterWithDelay()
    {
        if (CurrentDelay >0)
        {
            CurrentDelay -= Time.deltaTime;
        }
        else
        {
            float delay = Random.Range(MinDelaySpawn, MinDelaySpawn);
            CurrentDelay = delay;

            if (IsTime&& Boss < 1)
            {
                SpawnBoss();
            }
            else if(!IsTime)
            {
                SpawnMonster();
            }
        }
    }
    public void SpawnMonster()
    {
        int monindex = Random.Range(0, MonterPrefab.Length); //random 0-2
        GameObject thisMon = Instantiate(MonterPrefab[monindex]);//สั่งสร้าง

        thisMon.transform.parent = GameObject.Find("Canvas").transform;//ส่งเข้าแคนวาส
        float posX = Random.Range(LeftSpawnPoint.position.x, RightSpawnPoint.position.x);//สุ่มตำแหน่งการเกิด
        Vector2 spawnpos = new Vector2(posX, LeftSpawnPoint.position.y);//เอาตำแหน่งมาสุ่ม
        thisMon.transform.position = spawnpos;//ปรับตำแหน่ง
        thisMon.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);//ปรับขนาดม้อน
    }

    public void SpawnBoss()
    {
        GameObject thisMon = Instantiate(BossPrefab, BossSpawnPoint.transform.position, BossPrefab.transform.rotation);//สั่งสร้าง

        thisMon.transform.parent = GameObject.Find("Canvas").transform;//ส่งเข้าแคนวาส
        //float posX = Random.Range(LeftSpawnPoint.position.x, RightSpawnPoint.position.x);//สุ่มตำแหน่งการเกิด
        //Vector2 spawnpos = new Vector2(posX, LeftSpawnPoint.position.y);//เอาตำแหน่งมาสุ่ม
        //thisMon.transform.position = spawnpos;//ปรับตำแหน่ง
        thisMon.transform.localScale = new Vector3(2, 2, 2);//ปรับขนาดม้อน

        Boss++;
    }
    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
    }

    public void OKbtn()
    {
        SceneManager.LoadScene("Menu");
    }
}
