using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Save : MonoBehaviour
{
    public SaveData save;
    bool SavePoint;
    public bool isLoaded;

    [System.Serializable]
    public class SaveData
    {
        public string saveName;
        public Vector3 respawnPos;
        public bool SavePoint;
        public GameObject hp;
    }

    public static Save instance;  
   
    private void Awake()
    {
        instance = this;
        LoadPlayer();
    }

    void Update()
    {
        if (SavePoint = true && Input.GetKeyDown(KeyCode.I))
        {
            SavePlayer();
        }
    }

    public void SavePlayer()
    {
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + save.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, save);
        stream.Close();

        Debug.Log("已儲存");
    }

    public void LoadPlayer()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + save.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + save.saveName + ".save", FileMode.Open);
            save = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loading...");
            isLoaded = true;

        }
    }

    public void DeleteSavedData()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + save.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + save.saveName + ".save");
        }
    }

    /// <summary>
    /// 如果碰到存檔點並按下S鍵，才會進行存檔
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SavePoint")
        {
            SavePoint = true;
        }
    }
}
