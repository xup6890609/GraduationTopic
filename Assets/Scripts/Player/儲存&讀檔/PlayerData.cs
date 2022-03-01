using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    bool SavePoint;
    public int Level;
    public int hp;
    public float[] position;

    public PlayerData(HP player)
    {
        hp = player.hp;
    }

    void Update()
    {
        if(SavePoint && Input.GetKeyDown(KeyCode.S))
        {

        }
    }

    /// <summary>
    /// 如果碰到存檔點並按下S鍵，才會進行存檔
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SavePoint")
        {
            SavePoint = true;
        }
    }
}
