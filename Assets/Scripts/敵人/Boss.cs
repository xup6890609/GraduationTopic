using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    [Header("中心點")]
    public Transform atkPoint;
    [Header("中心點長度"), Range(0f, 5f)]
    public float atkLength;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float cd = 1f;

    public GameObject Bullet;
    public GameObject Bossmush;
    private Collider2D BTColl;
    public GameObject shrooms;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;

    //玩家座標
    //private Transform player;

    public GameObject player;

    public float attackrange;

    public float movespeed;


    // Start is called before the first frame update
    void Start()
    {
        BTColl = Bossmush.GetComponent<BoxCollider2D>();
        //player = GameObject.Find("Princess").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (shrooms.active == true)
        {
            
            CreatBullet();

            //執行生成子彈程式碼(一次)
            //Invoke("CreatBullet", 1);
            
        }
    }
    
    
    //追蹤
    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > attackrange)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }

        Vector2 direction = player.transform.position - transform.position;

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    /*
    ————————————————
    版权声明：本文为CSDN博主「可没就是说」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
    原文链接：https://blog.csdn.net/weixin_36190719/article/details/112884287
    */

    public void CreatBullet()
    {
        timer += Time.deltaTime;

        int BulletNum;
        //隨機決定要生成幾個子彈(0-2個隨機)
        BulletNum = UnityEngine.Random.Range(0, 2);

        if (timer >= cd)
        {
            //開始生成子彈
            for (int i = 0; i < BulletNum; i++)
            {
                //宣告生成的Y座標
                float y;
                //產生隨機的Y座標(-3到4之間)
                y = UnityEngine.Random.Range(-1.7f, 4f);

                //生成子彈
                Instantiate(Bullet, new Vector3(this.transform.position.x, y, 0), Quaternion.identity);

                timer = 0;
            }
        }

    }

    /// <summary>
    /// 繪製圖示事件 : 僅在 Unity 內顯示
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkPoint.position, atkPoint.forward * atkLength);
    }

}
