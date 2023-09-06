using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossShoot : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject BossBulletPrefab;
    public float ReloadTime;
    float currentReloadTime;

    public float RotSpeed = 180F;
    public bool Boss;
    Transform player;
    
    void Update()
    {
        Shoot();

        if (player == null)
        {
            GameObject go = GameObject.Find("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
            return;

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, RotSpeed * Time.deltaTime);
    }

    public void Shoot()  //Subfunction Delayกระสุน
    {
        if (currentReloadTime > 0)  //เช็ควลายิง
        {
            currentReloadTime -= Time.deltaTime; //นับเวลาถอยหลัง
        }
        else
        {
            if (Boss)
            {
                NormalShoot();
            }
            else if (!Boss)
            {
                NormalShoot();
            }
            currentReloadTime = ReloadTime;
        }
    }

    public void BoosShoot()  //ฟังช่นในกรสร้ากระสุน
    {
        GameObject thisBullet = Instantiate(BossBulletPrefab, ShootPoint.position + new Vector3(0, 0.5f, 0), transform.rotation);
        thisBullet.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet.transform.localScale = new Vector3(2, 2, 2);   
    }

    public void NormalShoot()  //ฟังช่นในกรสร้ากระสุน
    {
        GameObject thisBullet = Instantiate(BossBulletPrefab, ShootPoint.position + new Vector3(0, 0.5f, 0), transform.rotation);
        thisBullet.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet.transform.localScale = new Vector3(1, 1, 1);
    }
}
