using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject Settings;
    public AudioMixer audioMixer;
    public GameObject Lv2;
    public bool inLv2;
    bool PlayVideo;

    private void Start()
    {
        if (inLv2 == true)
            Lv2.SetActive(true);
        else
            Lv2.SetActive(false);
    }

    /// <summary>
    /// 播放片頭1秒後才顯示遊戲畫面
    /// </summary>
    IEnumerator WaitforTime()
    {
        if (PlayVideo == true)
        {
            SceneManager.LoadScene("片頭動畫");
            yield return new WaitForSeconds(1);
            StartGame();
        }
    }

    public void PlayVid()
    {
        PlayVideo = true;
        StartCoroutine(WaitforTime());
    }

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        print("開始遊戲");
        SceneManager.LoadScene("Lv.1");

    }

    /// <summary>
    /// 下一關
    /// </summary>
    public void NextLevel(string nameLV)
    {
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