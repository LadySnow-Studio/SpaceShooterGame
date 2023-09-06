using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    public float MoveSpeed;
    public GameObject GamePlay,PlayerOBJ, TopScreenPoint, BottomScreenPoint, LeftScreenPoint, RightScreenPoint, BulletPrefab, ExplodePrefab;
    public Transform ShootPoint;
    public float ReloadTime;
    float currentReloadTime;
    public GameObject[] Hearts;
    public int Hp;
    public GameObject GameOverScreen;
    public bool IsSpeed;
    public float Buffcount;

    void Start()
    {
        anim = GetComponent<Animator>();
        Hp = Hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp > 0)
        {
            MoveByKeyboard();
            Shoot();
        }

        if (IsSpeed)
        {
            Buffcount = 3;
            Buffcount -= Time.deltaTime;
        }
        {
            MoveSpeed = 5f;
        }

        ShowHeart();
        CallExploded();
        //ShowGameOverScreen();
        
    }
    public void ShowGameOverScreen()
    {
        GamePlay.SetActive(false);
        GameOverScreen.SetActive(true);
        GameOverScreen.transform.SetAsLastSibling();
    }
    public void ShowHeart()
    {
        for(int i = 0; i < Hearts.Length; i++)
        {
            if(Hp > i)
            {
                Hearts[i].SetActive(true);
            }
            else
            {
                Hearts[i].SetActive(false);
            }
        }
    }
    public void MoveByKeyboard() //ฟังช์ชั่นกดคีบอร์ด
    {
        if (transform.position.x > LeftScreenPoint.transform.position.x)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //การกดปุ่มบนคีบอดซ้าย
            {
                transform.Translate(-MoveSpeed*Time.deltaTime, 0, 0);
            }
        }
        if (transform.position.x < RightScreenPoint.transform.position.x)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //การกดปุ่มบนคีบอดขวา
            {
                transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
            }
        }
        if (transform.position.y < TopScreenPoint.transform.position.y)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) //การกดปุ่มบนคีบอดบน
            {
                transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
            }
        }
        if (transform.position.y > BottomScreenPoint.transform.position.y)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) //การกดปุ่มบนคีบอดล่าง
            {
                transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
            }
        }
    }

    public void Shoot()  //Subfunction Delayกระสุน
    {
        if(currentReloadTime > 0)  //เช็ควลายิง
        {
            currentReloadTime -= Time.deltaTime; //นับเวลาถอยหลัง
        }
        else
        {
            NormalShoot();
            currentReloadTime = ReloadTime;
        }
    }

    public void NormalShoot()  //ฟังช่นในกรสร้ากระสุน
    {
        GameObject thisBullet = Instantiate(BulletPrefab, ShootPoint.position, BulletPrefab.transform.rotation);
        thisBullet.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet.transform.localScale = new Vector3(1, 1, 1);
    }

    /*public void pantaShoot()
    {
        GameObject thisBullet1 = Instantiate(BulletPrefab, ShootPoint.position, BulletPrefab.transform.rotation);
        thisBullet1.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet1.transform.localScale = new Vector3(1, 1, 1);  //ยิงตรงกลาง

        GameObject thisBullet2 = Instantiate(BulletPrefab, ShootPoint.position, BulletPrefab.transform.rotation);
        thisBullet2.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet2.transform.localScale = new Vector3(1, 1, 1);
        thisBullet2.transform.eulerAngles = new Vector3(0, 0, 15);

        GameObject thisBullet3 = Instantiate(BulletPrefab, ShootPoint.position, BulletPrefab.transform.rotation);
        thisBullet3.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet3.transform.localScale = new Vector3(1, 1, 1);
        thisBullet3.transform.eulerAngles = new Vector3(0, 0, -15);

        GameObject thisBullet4 = Instantiate(BulletPrefab, ShootPoint.position, BulletPrefab.transform.rotation);
        thisBullet4.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet4.transform.localScale = new Vector3(1, 1, 1);
        thisBullet4.transform.eulerAngles = new Vector3(0, 0, 25);

        GameObject thisBullet5 = Instantiate(BulletPrefab, ShootPoint.position, BulletPrefab.transform.rotation);
        thisBullet5.transform.parent = GameObject.Find("Canvas").transform;                          //ย้ายกระสุนเข้าไปในแคนวาด
        thisBullet5.transform.localScale = new Vector3(1, 1, 1);
        thisBullet5.transform.eulerAngles = new Vector3(0, 0, -25);
    }*/

    public void OnTriggerEnter2D(Collider2D collision) //กระสุนโดนม้อนเด้อแล้วเลือดลด
    {
        if (collision.tag == "Monster")
        {
            Hp -= 1;
            anim.SetBool("GetHit", true);
            // collision.GetComponent<Moster>().CurrentHp -= 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("GetHit", false);
    }

    public void CallExploded()
    {
        if (Hp <= 0)
        {
            anim.SetBool("IsDie", true);
            GameObject thisExplode = Instantiate(ExplodePrefab, PlayerOBJ.transform.position, ExplodePrefab.transform.rotation);
            ShowGameOverScreen();
        }
    }

    public void DestroyRocket()
    {
        Destroy(gameObject);
    }

}
