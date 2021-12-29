using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum TrapMoveDir
    {
        None,
        Down,
        Up,
    }
    public float moveSpeed;//移動速度
    public bool isMove = true;//是否進行移動
    public Transform startTrans;//開始的點
    public Transform endTrans;//結束的點
    public Transform trapObj;//陷阱物體
    TrapMoveDir moveDir;//移動方向列舉
    public void TrapMove()
    {
        if (moveDir == TrapMoveDir.Down)
        {
            trapObj.transform.position += transform.up * moveSpeed * Time.deltaTime * -1;//朝下移動
            float distance = Vector3.Distance(trapObj.transform.position, startTrans.position);
            if (distance < 0.5f)//如果現在距離最下面的點小於0.5f，重新設定移動方向
            {
                moveDir = TrapMoveDir.Up;
            }
        }
        else if (moveDir == TrapMoveDir.Up)
        {
            trapObj.transform.position += transform.up * moveSpeed * Time.deltaTime;
            float distance = Vector3.Distance(trapObj.transform.position, endTrans.position);
            if (distance < 0.5f)
            {
                moveDir = TrapMoveDir.Down;
            }
        }
    }
}
