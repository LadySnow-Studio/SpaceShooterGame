using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager gm;

    public Transform TopLine;
    // Start is called before the first frame update
    void Start()
    {
        TopLine = GameObject.Find("TopScreenPoint").transform;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("SFXManager").SendMessage("PlayPlayerFireSound");
        //DestroySelf();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.IsBossDead == true)
        {
            Destroy(gameObject);
        }
        else if (gm.IsBossDead == false)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.Translate(0, 5*Time.fixedDeltaTime, 0); //Time.fixedBeltaTime ทำให้ยิงเท่ากันทุกเครื่อง

        if (transform.position.y >= TopLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject, 1.5f);
    }

    public void OnTriggerEnter2D(Collider2D collision) //กระสุนโดนม้อนเด้อแล้วเลือดลด
    {
        if(collision.tag == "Monster")
        {
            collision.GetComponent<Moster>().CurrentHp -= 10;
            Destroy(gameObject);
        }
    }
   

    //private void OnTriggerExit2D(Collider2D collision) //กระสุนผ่านไป
    //{

    //}

    //private void OnTriggerStay2D(Collider2D collision) //ทำงานเลือดจะลดเลื่อยนๆ
    //{

    //}
}
