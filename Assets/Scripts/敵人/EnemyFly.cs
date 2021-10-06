using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : Enemy    //繼承enemy的類別
{
    public float speed;
    public float startWithTime;
    public float waitTime;

    public Transform leftDownPos; //左下角座標
    public Transform rightUpPos;  //右上角座標
    public Transform movePos;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();    //調用父類的方法
        waitTime = startWithTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();    //調用父類的方法

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWithTime;
            }
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// 獲取隨機位置
    /// </summary>
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

}
