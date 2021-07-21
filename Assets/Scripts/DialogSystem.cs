using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;

    [Header("對話框文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("頭像")]
    public Sprite facePlayer, faceNPC;


    bool textFinished;

    List<string> textList = new List<string>();

    // 讀取文本中的文字
    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    /// <summary>
    /// 按R鍵讀取文本文字並循環
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && textFinished)
        {
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var LineData = file.text.Split('\n');       //將文本按行切割

        foreach(var line in LineData)               //循環
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";                        //清空文字

        /// <summary>
        /// 判斷文本裡頭符號對應的文字
        /// </summary>
        switch (textList[index])
        {
            case "A\r":
                faceImage.sprite = facePlayer;          //切換頭像
                index++;                                //略過這行
                break;

            case "B\r":
                faceImage.sprite = faceNPC;             //切換頭像
                index++;                                //略過這行
                break;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;                                     //增加行數
    }
}
