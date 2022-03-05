using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject Settings;
    public AudioMixer audioMixer;
    public GameObject Lv2;
    public bool inLv2;
    public GameObject player;


    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        inLv2 = false;
        print("開始遊戲");
        SceneManager.LoadScene("Lv.1");
    }

    /// <summary>
    /// 下一關
    /// </summary>
    public void NextLevel(string nameLV)
    {
        if (inLv2)
            Lv2.SetActive(true);
        else
            Lv2.SetActive(false);
        inLv2 = true;
        SceneManager.LoadScene(nameLV);
    }


    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void LeaveGame()
    {
        print("離開遊戲");
        Application.Quit();
    }

    /// <summary>
    /// 停止遊戲
    /// </summary>
    public void PauseGame()
    {
        Settings.SetActive(true);
        Time.timeScale = 0f;
    } 
    
    /// <summary>
    /// 回到遊戲
    /// </summary>
    public void BackToGame()
    {
        Settings.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// 回主選單
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("選單");
    }

    /// <summary>
    /// 死亡畫面
    /// </summary>
    public void DeadScene()
    {
        SceneManager.LoadScene("死亡畫面");
    }

    /// <summary>
    /// 設定音量
    /// </summary>
    /// <param name="value"></param>
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
}