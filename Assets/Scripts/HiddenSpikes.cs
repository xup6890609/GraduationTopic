using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpikes : MonoBehaviour
{
    public int damge;
    //public HP hp;

    // Start is called before the first frame update
    void Start()
    {
        //hp = GameObject.FindGameObjectsWithTag("Player").GetComponent<HP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
