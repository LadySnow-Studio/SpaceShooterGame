using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moster : MonoBehaviour
{
    Animator anim;
    public int CurrentHp, MaxHp;   //current Hpปุจบัน  MaxHp เลือดเต็มเท่าไหร่
    public Image HpBar;
    public float MoveSpeed;
    public int ScorePoint;
    GameManager gm;
    public Transform BottomPoint;
    public GameObject ExemiPrefab, EmiPrefab;
    public bool IsBoss;

    public GameObject[] ItemsPrefab;
    public int MinItemDropAmount, MaxItemDropAmount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CurrentHp = MaxHp;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        BottomPoint = GameObject.Find("BottomScreenPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        ShowHpBar();

        if (IsBoss)
        {

        }
        else
        {
            Move();
        }
        
        if(CurrentHp <= 0)
        {
            anim.SetBool("IsDie", true);
        }
    }
    public void ShowHpBar()
    {
        HpBar.fillAmount = (float)CurrentHp / (float)MaxHp;
    }
    
    public void Move()
    {
        transform.Translate(0, -MoveSpeed * Time.fixedDeltaTime, 0);
        if (transform.position.y <= BottomPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    public void CallEffect()
    {
        GameObject thisgameObject = Instantiate(ExemiPrefab, EmiPrefab.transform.position, ExemiPrefab.transform.rotation);
    }

    public void DropItem()
    {
        int rndAmount = Random.Range(MinItemDropAmount, MaxItemDropAmount);
        if (rndAmount > 0)
        {
            for (int i = 0; i < rndAmount; i++)
            {
                int rnditemtype = Random.Range(0, ItemsPrefab.Length);
                GameObject thisItem = Instantiate(ItemsPrefab[rnditemtype], //สั่งสร้างพีเเฟป
                    transform.position, transform.rotation); //สั่งสร้างพีเเฟป

                thisItem.transform.parent = GameObject.Find("Canvas").transform;//ส่งเข้าแคนวาส
                thisItem.transform.localScale = new Vector3(40, 40, 40);//ปรับขนาดม้อน

                GameObject.Find("SFXManager").SendMessage("PlayDropItem");
            }
        }
    }

    public void DestroySelf()
    {
        if (IsBoss)
        {
            gm.IsBossDead = true;
        }
        gm.Score += ScorePoint;
        Destroy(gameObject);
    }

    public void CallBombSound()
    {
        GameObject.Find("SFXManager").SendMessage("PlayBombSound");
    }
}
