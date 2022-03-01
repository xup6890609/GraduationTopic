using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject Settings;
    public AudioMixer audioMixer;
    public int level = 1;
    public int hp;
    Vector2 playerPosition;

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
    /// 儲存遊戲
    /// </summary>
    public void SaveGame()
    {
        SaveManager.Save(this);
    }

    /// <summary>
    /// 讀取遊戲
    /// </summary>
    public void LoadGame()
    {
        SaveData data = SaveManager.LoadGame();
        level = data.level;
        hp = data.hp;

        transform.position = playerPosition;
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