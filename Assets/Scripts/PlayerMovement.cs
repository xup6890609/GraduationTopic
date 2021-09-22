using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;
    private float horizontalMove;
    public Transform groundCheck;
    public LayerMask ground;
    
    /*
    public GameObject heart01;
    宣告愛心01
    public GameObject heart02;
    宣告愛心02
    public GameObject heart03;
    宣告愛心3
    */

    //CD圖示
    [Header("CD時間的UI組件")]
    public Image CDImage;


    //衝刺參數調整
    [Header("衝刺時間")]
    public float dashTime;          
    private float dashLeft;           //衝刺剩餘時間

    [Header("衝刺速度")]
    public float dashSpeed;         
    private float LastDash = -10f;    //上次衝刺時間點
    
    [Header("冷卻時間")]
    public float dashCoolDown;

    public bool isGround, isJump, isDashing;

    bool jumpPressed;

    // 跳躍次數
    int jumpCount;
    //宣告愛心數量=3
    //int HeartNum = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }

        //如果按下"Z"鍵，遊戲時間已大於等於上次衝刺時間和CD時間，就執行衝刺
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.time >= LastDash + dashCoolDown)
            {
                ReadyToDash();
            }
        }

        CDImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;
        Physics.gravity = new Vector3(0, -1000f, 0);
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        
        Dash();
        if (isDashing)      ///執行衝刺時///
          return;           ///不進行其他動作///
          
        GroundMovement();

        Jump();


        SwitchAnim();
    }

    /*
    private void OnTriggerStay2D(Collider2D other)  //玩家碰到傷害會執行
    {
        if (other.tag == "danger")  //碰到tag是danger時，扣一顆心
        {
            //刪除怪物
            Destroy(collision.gameObject);

            HeartNum = HeartNum - 1;
            //愛心數量減一

            //根據愛心數量顯示愛心圖案
            if (HeartNum == 2)  //如果還有三顆愛心
            {
                heart01.SetActive(false);
                //第一顆愛心隱藏
            }
            else if(HeartNum == 1)  //如果剩兩顆愛心
            {
                heart02.SetActive(false);
                //第二顆愛心隱藏
            }
            else if (HeartNum == 1)  //如果剩一顆愛心
            {
                heart03.SetActive(false);
                //第三顆愛心隱藏
            }
        }
    }
    */

    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");//只返回-1，0，1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }

    }

    void Jump()//跳跃
    {
        if (isGround)
        {
            jumpCount = 2;//可跳躍數量
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }

    void SwitchAnim()//動畫切换
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if (!isGround && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }

    void ReadyToDash()
    {
        isDashing = true;

        dashLeft = dashTime;
        LastDash = Time.time;
        CDImage.fillAmount = 1;
    }

    void Dash()
    {
        if (isDashing)
        {
            if(dashLeft > 0)
            {
                if(rb.velocity.y > 0 && !isGround)
                {
                    rb.velocity = new Vector2(dashSpeed * horizontalMove, jumpForce);
                }
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);

                dashLeft -= Time.deltaTime;

                ShadowPool.instance.GetFromPool();
            }
            if(dashLeft <= 0)
            {
                isDashing = false;
                if (!isGround)
                {
                    rb.velocity = new Vector2(dashSpeed * horizontalMove, jumpForce);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collection")
        {
            Destroy(collision.gameObject);

        }
    }

    //如果玩家攻擊妖怪，妖怪就消失
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (anim.GetBool("Attack"))
        {
            if (collision.gameObject.tag == "Monster")
            {
                Destroy(collision.gameObject);
                //Player.sprite = WithMonster;
            }
        }
    }
}
