using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [Header("血量")]
    public int hp; // 初始值
    public int NumofHearts; // 現有值
    public GameObject heart01, heart02, heart03;

    [Header("血量的圖片")]
    public Image[] hearts;
    public Sprite HP_Full;
    public Sprite HP_0;
    public GameObject player;

    [Header("音效")]
    public AudioSource hurtAudio;       //受傷音效
    public AudioSource healAudio;       //增血音效

    private void Start()
    {
        hurtAudio = GetComponent<AudioSource>();

    }

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

    /// <summary>
    /// 減血
    /// </summary>
    internal void LoseLife()
    {
        //hp = 0 時(減少計算用)
        if (NumofHearts == 0)
            return;

        //扣hp的值
        NumofHearts--;
        
        //hp圖片變成空心狀態
        hearts[NumofHearts].enabled = false;
        hurtAudio.Play();
        //沒有心心時，玩家死亡
        if(NumofHearts == 0)
        {
           FindObjectOfType<PlayerMovement>().Dead();
        }
    }

    /// <summary>
    /// 增血
    /// </summary>
    internal void Heal()
    {
        if (NumofHearts == 0)
            return;
        NumofHearts += 1;
        hp += 1;
        hearts[NumofHearts].enabled = true;
        healAudio.Play();
        /*heart01.SetActive(true);
        heart02.SetActive(true);
        heart03.SetActive(true);
        heart04.SetActive(true);*/
    }

    internal void AddHpMax()
    {
        hp++;
        hp = Mathf.Clamp(hp, 0, NumofHearts);
        Update();
    }
}
