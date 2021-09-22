using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    [Header("基本參數")]
    public float speed =10f, jumpForce = 3f;
    private float horizontalMove;
    private float crouchSpeed = 3f;
    public Transform groundCheck;
    public LayerMask ground;

    [Header("動作狀態")]
    public bool isGround, isJump, isCrouch, isDashing ;
    bool jumpPressed;
    int jumpCount;  //跳躍次數

    /// <summary>
    /// 碰撞體尺寸調整(讓下蹲時可以穿越障礙物)
    /// </summary>
    private Vector2 colliderStandSize; //站立時的尺寸
    private Vector2 colliderStandOffset; //站立時的座標
    private Vector2 colliderCrouchSize; //下蹲時的尺寸
    private Vector2 colliderCrouchOffset; //下蹲時的座標

    //CD圖示
    [Header("CD時間的UI組件")]
    public Image CDImage;

    [Header("血量")]
    public GameObject hp;

    //[Header("角色圖片切換")]
    //public AnimatorOverrideController FloatingAnim;   //漂浮
    //public AnimatorOverrideController CrashingAnim;   //衝撞


    //衝刺參數調整

    [Header("衝刺時間")]
    public float dashTime;
    private float dashLeft;           //衝刺剩餘時間

    [Header("衝刺速度")]
    public float dashSpeed;
    private float LastDash = -10f;    //上次衝刺時間點

    [Header("冷卻時間")]
    public float dashCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        colliderStandSize = coll.size;
        colliderStandOffset = coll.offset;
        colliderCrouchSize = new Vector2(coll.size.x, coll.size.y / 2f);
        colliderCrouchOffset = new Vector2(coll.offset.x, coll.offset.y / 2f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
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

    /// <summary>
    /// 地面移動
    /// </summary>
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");//值只返回-1，0，1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y); //一般狀態下的值
        
        //下蹲狀態下的值
        if (isCrouch)
        {
            horizontalMove /= crouchSpeed;
        }

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }

        //如果按下unity預設下蹲按鍵，就執行"下蹲"動作
        if (Input.GetButton("Crouch"))
        {
            Crouch();
        }

        //如果沒有，則自動執行"起立"動作
        else if(!Input.GetButton("Crouch") && isCrouch)
        {
            StandUp();
        }

        FilpDirction();
    }

    /// <summary>
    /// 翻轉左右方向
    /// </summary>
    void FilpDirction()
    {
        if (horizontalMove > 0)
            transform.localScale = new Vector2(1, 1);
        if (horizontalMove < 0)
            transform.localScale = new Vector2(-1, 1);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    void Jump()
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

    /// <summary>
    /// 下蹲
    /// </summary>
    void Crouch()
    {
        isCrouch = true;
        coll.size = colliderCrouchSize;
        coll.offset = colliderCrouchOffset;
    } 
    
    /// <summary>
    /// 起立
    /// </summary>
    void StandUp()
    {
        isCrouch = false;
        coll.size = colliderStandSize;
        coll.offset = colliderStandOffset;
    }

    /// <summary>
    /// 切換動畫動作
    /// </summary>
    void SwitchAnim()
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

    /// <summary>
    /// 準備衝刺
    /// </summary>
    void ReadyToDash()
    {
        isDashing = true;

        dashLeft = dashTime;
        LastDash = Time.time;
        CDImage.fillAmount = 1;
    }

    /// <summary>
    /// 衝刺
    /// </summary>
    void Dash()
    {
        if (isDashing)
        {
            if (dashLeft > 0)
            {
                if (rb.velocity.y > 0 && !isGround)
                {
                    rb.velocity = new Vector2(dashSpeed * horizontalMove, jumpForce);
                }
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);

                dashLeft -= Time.deltaTime;

                ShadowPool.instance.GetFromPool();
            }
            if (dashLeft <= 0)
            {
                isDashing = false;
                if (!isGround)
                {
                    rb.velocity = new Vector2(dashSpeed * horizontalMove, jumpForce);
                }
            }
        }
    }

    //切換角色顯示動畫
   // public void FloatSkin()
    //{
   //     GetComponent<Animator>().runtimeAnimatorController = FloatingAnim as RuntimeAnimatorController;
   // }

    //public void CrashSkin()
    //{
    // GetComponent<Animator>().runtimeAnimatorController = CrashingAnim as RuntimeAnimatorController;
    // }

    //如果玩家碰到收集物件，收集物件就消失
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);

        }
    }

    //如果玩家攻擊妖怪，妖怪就消失
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DashMonster")
        {
            if (Time.time >= LastDash + dashCoolDown)
            {
                Destroy(collision.gameObject);
                ReadyToDash();
            }

            CDImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;
            Physics.gravity = new Vector3(0, -1000f, 0);
        }

        if (collision.gameObject.tag == "Monster")
        {
            hp.GetComponent<HP>().LoseLife();

        }

        if (anim.GetBool("Attack"))
        {
            if (collision.gameObject.tag == "Monster")
            {
                Destroy(collision.gameObject);
               // FloatSkin();
            }
            else
            {

            }

        }
    }
    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {

    }
}
