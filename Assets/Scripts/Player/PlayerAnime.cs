using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    Animator anim;
    PlayerMovement movement;

    /// <summary>
    /// 設定編號
    /// </summary>
    int idleID;
    int crouchID;
    int climbID;
    int jumpingID;
    int runningID;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();

        /// <summary>
        /// 編號對應Animator的數值 (Unity Animator視窗的控制動畫的參數)
        /// (StringToHash:把「字符形」程式轉成「數字」)
        /// </summary>
        idleID = Animator.StringToHash("Idle");
        runningID = Animator.StringToHash("running");
        crouchID = Animator.StringToHash("Crouch");
        climbID = Animator.StringToHash("Climb");
        jumpingID = Animator.StringToHash("Jumping");

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(runningID, Mathf.Abs(movement.horizontalMove)); //判斷在animator面板中的值是否為0
        anim.SetBool(idleID, movement.isGround);
        anim.SetBool(crouchID, movement.isCrouch);
        anim.SetBool(climbID, movement.isClimbing);
        anim.SetBool(jumpingID, movement.isJump);
    }
}
