using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int hp;
    public int NumofHearts;

    //血量的圖片
    public Image[] hearts;
    public Sprite HP_Full;
    public Sprite HP_0;
    public GameObject player;

    private void Update()
    {
        if(hp > NumofHearts)
        {
            hp = NumofHearts;
        }
        for (int i = 0 ; i< hearts.Length ; i++)
        {
            if(i < hp)
            {
                hearts[i].sprite = HP_Full;
            }
            else
            {
                hearts[i].sprite = HP_0;
            }
            if(i < NumofHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    internal void LoseLife()
    {
        //hp = 0 時
        if (NumofHearts == 0)
            return;

        //扣hp的值
        NumofHearts--;
        
        //hp圖片變成空心狀態
        hearts[NumofHearts].enabled = false;

        //沒有心心時，玩家死亡
        if(NumofHearts == 0)
        {
           FindObjectOfType<PlayerMovement>().Dead();
        }
    }
}
