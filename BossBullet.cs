using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //seeking
    public Transform Destination;
    public float DistanceForSeeking;
    public Transform BottomLine;
    public float MoveSpeed, MaxDistanceForSeek, MaxDistanceForAttack;
    public float DirBullet;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        BottomLine = GameObject.Find("BottomScreenPoint").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GameObject.Find("SFXManager").SendMessage("PlayEnemyFireSound");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float distanceX = transform.position.x - player.transform.position.x; //ม้อนหาแนวแกนเอค
        float distanceY = transform.position.y - player.transform.position.y;
        float distancev2 = Vector2.Distance(transform.position, player.transform.position); //ม้อนหาแนวทะแยง

        float absDistanceX = Mathf.Abs(distanceX); //ถอดแอปโซลูท
        float absDistanceY = Mathf.Abs(distanceY);

        Destination = player.transform;
        transform.Translate(0, -DirBullet * Time.fixedDeltaTime, 0); //Time.fixedBeltaTime ทำให้ยิงเท่ากันทุกเครื่อง

        if (transform.position.y <= BottomLine.transform.position.y)
        {
            Destroy(gameObject, 1f);
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject, .5f);
    }

    public void OnTriggerEnter2D(Collider2D collision) //กระสุนโดนม้อนเด้อแล้วเลือดลด
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().Hp -= 1;
            Destroy(gameObject);
        }
    }
}
