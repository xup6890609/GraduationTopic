using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public bool setActive = false;
    public GameObject Dialog;
    public GameObject Player;
    public GameObject show;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            setActive = true;
            Dialog.SetActive(true);
            Destroy(show.gameObject);
        }
        
    }
}
