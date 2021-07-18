using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    private Rigidbody2D rig;
    private float FallMultiplier = 2.5f;
    private float LowMultiplier = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.y < 0)
        {
            rig.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;

        }
        else if (rig.velocity.y < 0 && !Input.GetButton("Jump"))     //&& and;        ! not;
        {
            rig.velocity += Vector2.up * Physics2D.gravity.y * (LowMultiplier - 1) * Time.deltaTime;
        }
    }
}
