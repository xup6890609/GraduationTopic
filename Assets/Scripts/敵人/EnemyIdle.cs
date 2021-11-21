using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    public Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public Transform pos;

    //獲得移動的位置
    public Transform Left, Right;
    public float speed;
    private float leftX, rightX;

    private bool isLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        leftX = Left.position.x;
        rightX = Right.position.x;
        Destroy(Left.gameObject);
        Destroy(Right.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (isLeft)
        {
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            if (transform.position.x < leftX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isLeft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            if (transform.position.x > rightX)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isLeft = true;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(rb, pos.position, pos.rotation);
        }
    }
}
