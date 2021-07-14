using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject Settings;
    public AudioMixer audioMixer;

    public void StartGame()
    {
        print("開始遊戲");
        SceneManager.LoadScene("Lv.1");
    }
    public void LeaveGame()
    {
        print("離開遊戲");
        Application.Quit();
    }

    public void PauseGame()
    {
        Settings.SetActive(true);
        Time.timeScale = 0f;
    } 
    
    public void BackToGame()
    {
        Settings.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
}