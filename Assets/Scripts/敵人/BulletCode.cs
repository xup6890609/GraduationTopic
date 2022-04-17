using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    [Header("法術壽命"), Range(50, 70)]
    public float cd = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //每一偵子彈向右飛行
        this.transform.position += new Vector3(0.07f, 0, 0);
    }
    //下面這個函式是當子彈碰撞到其他物體時會執行
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果碰到頂端牆壁，摧毀法術(為了不讓法術無限飛行)(還沒做的優化)
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if (other.name == "Wall_4")
        {
            Destroy(this.gameObject);
        }
    }

}
