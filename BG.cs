using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TopBorder, BottomBorder;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(0, -0.005f, 0);

        if (transform.position.y <= BottomBorder.transform.position.y) //เอาไว้เช็คจุดเหลืองทาแนวตั้ง
        {
            transform.position = new Vector3(transform.position.x, TopBorder.transform.position.y, transform.position.z);
        }
    }

}
