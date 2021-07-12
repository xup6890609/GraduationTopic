using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    //從這個腳本叫到其他腳本上的方式
    public static ShadowPool instance;
    public GameObject shadowPrefab;
    public int shadowCount;

    //pool = 物件池 優化系統，重複使用一些頻繁被取用的資源，來減少建立、銷毀的運算消耗。
    private Queue<GameObject> availableObjects = new Queue<GameObject>();
   
    private void Awake()
    {
        instance = this;
        FillPool();             //初始化物件池
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++) ;
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);

            ReturnPool(newShadow);      //取消啟用，並返回物件池
        }
    }
    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            FillPool();
        }

        //Dequeue  是用來清除第一個字串。
        var outShadow = availableObjects.Dequeue();
        outShadow.SetActive(true);                  //一旦true，就執行ShadowSprite裡的OnEnable程式。

        return outShadow;
    }
}
