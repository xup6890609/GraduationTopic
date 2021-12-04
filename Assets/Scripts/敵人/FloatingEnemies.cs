using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemies : MonoBehaviour
{
    public Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public Transform pos;


    //獲得移動的位置
    public Transform Top, Bottom;
    public float speed;
    private float TopY, BottonY;

    private bool isUp = true;

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

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "DashMonster")
        {
            if (collision.gameObject.tag == "Player")
            {
                Instantiate(rb, pos.position, pos.rotation);
            }
        }

    }*/


}
