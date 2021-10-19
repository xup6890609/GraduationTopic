using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbOnLadder : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool OnLadder;
    public float climbSpeed;

    private void Start()
    {
        OnLadder = true;
    }
    void ClimbOn(float horizontal,float vertical)
    {
        if (OnLadder)
        {
            rb.velocity = new Vector2(horizontal * climbSpeed, vertical * climbSpeed);
        }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        ClimbOn(horizontal, vertical);
    }
}
