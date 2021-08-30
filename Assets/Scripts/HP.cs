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

        private void Update()
    {
        if(hp > NumofHearts)
        {
            hp = NumofHearts;
        }
       
    }

    public void LoseLife()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
            {
                hearts[i].sprite = HP_Full;
            }
            else
            {
                hearts[i].sprite = HP_0;
            }
            if (i < NumofHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        //心心數量減少
        NumofHearts--;
        
        //心心數 =0 時，遊戲結束
        if(NumofHearts == 0)
        {
            Debug.Log("遊戲結束");
            return;
        }
    }
}
