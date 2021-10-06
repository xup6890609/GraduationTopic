using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float FallMultiplier = 2.5f;
    private float LowMultiplier = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //掉落
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;

        }
        //小跳
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))     //&& and;        ! not;
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (LowMultiplier - 1) * Time.deltaTime;
        }
    }
}
