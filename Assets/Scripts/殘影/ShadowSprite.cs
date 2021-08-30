using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform Player;
    
    private SpriteRenderer SR;
    private SpriteRenderer PlayerSprite;
   
    private Color color;

    [Header("時間控制參數")]
    public float activeTime;        //顯示時間
    public float activeStart;       //開始顯示的時間點

    [Header("不透明度控制參數")]
    private float alpha;
    public float alphaSet;          //透明度初始值
    public float alphaMutiplier;

    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        SR = GetComponent<SpriteRenderer>();
        PlayerSprite = Player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        SR.sprite = PlayerSprite.sprite;
        transform.position = Player.position;
        transform.localScale = Player.localScale;
        transform.rotation = Player.rotation;

        activeStart = Time.time;
    }

    void Update()
    {
        alpha *= alphaMutiplier;

        color = new Color(0.5f, 0.5f, 1,alpha); //顏色分別為原圖的R，G，B(紅綠藍)，透明度
        SR.color = color;

        //如果時間超過設置的時間，就將物件發回物件池。
        if (Time.time >= activeStart + activeTime)
        {
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }



}
