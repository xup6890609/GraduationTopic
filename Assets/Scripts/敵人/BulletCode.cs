using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //每一偵子彈向右飛行
        this.transform.position += new Vector3(0.1f, 0, 0);
    }
    //下面這個函式是當子彈碰撞到其他物體時會執行
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果碰到頂端牆壁，摧毀子彈(為了不讓子彈無限飛行)(還沒做的優化)
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
