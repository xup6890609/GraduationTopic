using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    [Header("環境檢測")]
    public LayerMask ground;

    [Header("血量")]
    public GameObject hp;

    [Header("移動參數")]
    public float speed = 10f;
    public float crouchSpeed = 3f;  //蹲下速度
    public float horizontalMove;  //水平移動

    [Header("跳躍參數")]
    public float jumpForce = 6.3f;
    public Transform Ground;
    public float groundRedius;
    private int extraJump;
    public int extraJumpValue;
    /*public float jumpHoldForce = 0.1f;
    public float jumpHoldDuration = 0.1f;
    public float crouchJumpBoost = 2.5f; //跳躍額外加成*/
    private float jumpTime;

    [Header("動作狀態")]
    public bool isGround;
    public bool isJump;
    public bool isCrouch;
    public bool isDashing;
    bool jumpPressed; //單次跳躍
    /*bool jumpHeld;   //長按跳躍*/
    bool crouchHeld; //長按下蹲
    bool isRun;
    bool isDead = false;

    [Header("攀爬參數")]
    private float climb;
    float climbSpeed = 8f;
    bool isLadder;
    bool isClimbing;

    [Header("場景轉換")]
    public static PlayerMovement instance;
    public string scenePassword;



    /// <summary>
    /// 碰撞體尺寸調整(讓下蹲時可以穿越障礙物)
    /// </summary>
    private Vector2 colliderStandSize; //站立時的尺寸
    private Vector2 colliderStandOffset; //站立時的座標
    private Vector2 colliderCrouchSize; //下蹲時的尺寸
    private Vector2 colliderCrouchOffset; //下蹲時的座標

    //CD圖示
   // [Header("CD時間的UI組件")]
   // public Image CDImage;


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

   /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
              Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        coll = GetComponent<BoxCollider2D>();
        colliderStandSize = coll.size;
        colliderStandOffset = coll.offset;
        colliderCrouchSize = new Vector2(coll.size.x, coll.size.x );
        colliderCrouchOffset = new Vector2(coll.offset.x, coll.offset.y / 2f);

    }

    // Update is called once per frame
    void Update()
    {
        jumpPressed = Input.GetButtonDown("Jump");
        /*jumpHeld = Input.GetButton("Jump");*/
        crouchHeld = Input.GetButton("Crouch");
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
        GroundMovement();
        Jump();
        Run();
        Climb();
        Dash();
        if (isDashing)      ///執行衝刺時///
            return;           ///不進行其他動作///
       // SwitchAnim();
    }

    /// <summary>
    /// 物理判斷
    /// </summary>
    void PhysicsCheck()
    {
        if (coll.IsTouchingLayers(ground))
            isGround = true;
        else isGround = false;
    }


    /// <summary>
    /// 地面移動
    /// </summary>
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");//值只返回-1，0，1
       
        //下蹲狀態下的值
        if (isCrouch)
        {
            horizontalMove /= crouchSpeed;
        }
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y); //一般狀態下的值

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }

        //如果按下unity預設下蹲按鍵，就執行"下蹲"動作
        //如果按下unity預設下蹲按鍵 + 角色判斷在地面上，就執行"下蹲"動作
        if (crouchHeld && !isCrouch && isGround)
        {
            Crouch();
        }

        //如果沒有，則自動執行"起立"動作
        else if(!crouchHeld && isCrouch )
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

    void Run()
    {
        if (isJump)
        {
            isRun = true;
            horizontalMove = Input.GetAxisRaw("Horizontal");
        }
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    void Jump()
    {
        isGround = Physics2D.OverlapCircle(Ground.position, groundRedius, ground);
        extraJump = extraJumpValue;

        //如果按↑鍵 且 extraJump的值 >0，就執行加成跳躍
        if (jumpPressed && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (jumpPressed && extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        /*if (jumpPressed && isGround  )
        {
            if(isCrouch)
            {
                StandUp();

            }
            isGround = false;
            isJump = true;
            jumpTime = Time.time + jumpHoldDuration;
            
            rb.AddForce(new Vector2(0f, crouchJumpBoost), ForceMode2D.Impulse);//添加二維方向的力
        }
    

        else if (isJump)
        {
            /*if (jumpHeld)
            {
                rb.AddForce(new Vector2(0f, jumpHoldForce), ForceMode2D.Impulse); //添加二維方向的力
            }*/
            /*if(jumpTime < Time.time)
            {
                isJump = false;
            }
        }*/
    }

    /// <summary>
    /// 爬梯子
    /// </summary>
    void Climb()
   {
        climb = Input.GetAxis("Climb");
        
        if(isLadder && Mathf.Abs(climb) > 0f)
        {
            isClimbing = true;
        }

        if (isClimbing)
        {
           rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, climb * climbSpeed);
        }

        else
        {
            rb.gravityScale = 1f;
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
    /// 準備衝刺
    /// </summary>
    public void ReadyToDash()
    {
        isDashing = true;

        dashLeft = dashTime;
        LastDash = Time.time;
        //CDImage.fillAmount = 1;
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

        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }

        if (collision.tag == "Trap")
        {
            hp.GetComponent<HP>().LoseLife();        
        }

        if(collision.tag == "Bullet")
        {
            hp.GetComponent<HP>().LoseLife();
        }

        if(collision.tag == "HealGem")
        {
            Destroy(collision.gameObject);
            hp.GetComponent<HP>().Heal();
        }

        if (collision.tag == "+HPmax")
        {
            Destroy(collision.gameObject);
            hp.GetComponent<HP>().AddHpMax();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    /// <summary>
    /// 衝刺怪動作
    /// </summary>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "DashMonster")
        {
            if (Time.time >= LastDash + dashCoolDown)
            {
                ReadyToDash();
                //Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   //如果玩家碰到衝刺妖怪，玩家執行衝刺、衝刺妖怪消失
       /* if (collision.gameObject.tag == "DashMonster")
        {
            if (Time.time >= LastDash + dashCoolDown)
            {
                Destroy(collision.gameObject);
                ReadyToDash();
            }

            //CDImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;
            Physics.gravity = new Vector3(0, -1000f, 0);
        }*/
        //如果玩家碰到妖怪，玩家損血
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
        anim.SetTrigger("Die");
        isDead = true;
        FindObjectOfType<MenuManager>().DeadScene();
    }

    /// <summary>
    /// 重置玩家
    /// </summary>
    public void ResetPlayer()
    {
        isDead = false;
    }
}
