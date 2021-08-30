using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemies : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    //獲得移動的位置
    public Transform Top, Bottom;
    public float speed;
    private float TopY, BottonY;

    private bool isUp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        TopY = Top.position.y;
        BottonY = Bottom.position.y;
        Destroy(Top.gameObject);
        Destroy(Bottom.gameObject);
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (isUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > TopY)
            {
                isUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if(transform.position.y < BottonY)
            {
                isUp = true;
            }
        }
    }
}
