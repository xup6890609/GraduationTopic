using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);
        healthSystem.Damage(10);
        healthSystem.Heal(10);
        Debug.Log("Health:" + healthSystem.GetHealth());
        Debug.Log("Health:" + healthSystem.GetHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
