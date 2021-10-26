using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string sceneName;
    //[SerializeField]用於變量設為 private 但同時希望它顯示在編輯器中
    [SerializeField] private string newScenePassword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement.instance.scenePassword = newScenePassword;
            SceneManager.LoadScene(sceneName);
        }
    }
}
