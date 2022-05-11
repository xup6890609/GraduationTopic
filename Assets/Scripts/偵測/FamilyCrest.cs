using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyCrest : MonoBehaviour
{
    [Header("家徽碎片收集物")]
    public GameObject CrestClips;

    [Header("UI上的家徽圖片")]
    public Image Crest;

    [Header("家徽數量")]
    public int amount;
    public int fullAmount;

    [Header("音效")]
    public AudioSource collectAudio;       //收集音效
    public AudioSource collapseAudio;      //倒塌音效

    [Header("下一關檔板")]
    public GameObject GoToNext;
    

    /// <summary>
    /// 初始值&最大值
    /// </summary>
    private void Start()
    {
        amount = 0;
        fullAmount = amount;
    }
    
    /// <summary>
    /// 如果獲得碎片，UI畫面就顯示
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CrestClips")
        {
            Destroy(other.gameObject);
            amount += 1;
            fullAmount = amount;
            Crest.fillAmount += 0.2f;
            collectAudio.Play();
        }

        //如果達到最大值，刪除檔板
        if (fullAmount == 5)
        {
            Destroy(GoToNext);
            collapseAudio.Play();
        }
    }
}
