using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemTypes
    {
        SpeedBoost, FillHp, FakeItem
    }

    public ItemTypes ItemType;
    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GenerateItemEffect();
            GameObject.Find("SFXManager").SendMessage("PlayRecievedItem");
            Destroy(gameObject);
            //GameObject.Find("SFXManager").SendMessage("PlayPickUpSound");
        }
    }

    public void GenerateItemEffect()
    {
        switch (ItemType)
        {
            case ItemTypes.FakeItem:

                break;
            case ItemTypes.FillHp:
                if (player.Hp < 3)
                {
                    player.Hp++;
                }
                //rabbit.Hp = rabbit.Hp + 1 > rabbit.Hearts.Length ? rabbit.Hearts.Length : rabbit.Hp + 1;
                //  GameObject.Find("SFXManager").SendMessage("PlayPickUpSound");
                break;
            case ItemTypes.SpeedBoost:
                player.MoveSpeed += 2f;
                player.IsSpeed = true;
            
                break;
        }
    }
}
