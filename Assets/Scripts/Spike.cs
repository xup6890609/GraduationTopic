﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damge;
    //public PlayerHelth playerHelth;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerHelth = GameObject.FindGameObjectsWithTag("UI").GetComponent<HP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //PlayerHelth.DamegePlayer(damge);
        }
    }
}
