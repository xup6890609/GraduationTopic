using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterName : MonoBehaviour
{
    [Header("角色名稱")]
    public Text Name;

    [Header("對話框文件")]
    public TextAsset CharName;
    public int index;
    public float textSpeed;

    bool textFinished;

    List<string> textList = new List<string>();

    // 讀取文本中的文字
    void Awake()
    {
        GetTextFromFile(CharName);
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
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
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

    void GetTextFromFile(TextAsset Name)
    {
        textList.Clear();
        index = 0;

        var LineData = Name.text.Split('\n');       //將文本按行切割

        foreach (var line in LineData)               //循環
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        Name.text = "";                        //清空文字

        /// <summary>
        /// 判斷文本裡頭符號對應的文字
        /// </summary>
        switch (textList[index])
        {
            case "A\r":
                index++;                                //略過這行
                break;

            case "B\r":
                index++;                                //略過這行
                break;
        }
        for (int i = 0; i < textList[index].Length; i++)
        {
            Name.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;                                     //增加行數
    }




}
