using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    //先在變數端宣告要SetActive的物件
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        //初始化時先設定成關閉
        Boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Boss.SetActive(true);
        }
    }

}
