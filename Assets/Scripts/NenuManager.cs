using UnityEngine;
using UnityEngine.SceneManagement;

public class NenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LV1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
