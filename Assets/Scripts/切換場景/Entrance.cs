using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string enterPassword;


    private void Start() 
    {
        if (PlayerMovement.instance.scenePassword == enterPassword)
        {
            PlayerMovement.instance.transform.position = transform.position;    //transform.position等於enter position
            Debug.Log("enter");
        }
        else
        {
            Debug.Log("Wrong Password");
        }
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
