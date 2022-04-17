using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3Boss : MonoBehaviour
{
    //public Transform leftDownPos; //左下角座標
    //public Transform rightUpPos;  //右上角座標
    //public Transform movePos;

    public Transform playerTransform;
    //lv3boss
    public GameObject lv3boss;
    //玩家
    public GameObject player;
    //偵測停止距離
    public float attackrange;
    //移動速度
    public float dashspeed;

    private int randommovechoseNum;
    [Header("冷卻時間"), Range(0, 50)]
    public float cd = 15f;
    [Header("攻擊0冷卻時間"), Range(0, 50)]
    public float atk0cd = 3f;
    [Header("攻擊1冷卻時間"), Range(0, 50)]
    public float atk1cd = 30f;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    private float atk0timer;
    private float atk1timer;

    public GameObject dartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randommovechoseNum = Random.Range(0, 2);
        print(randommovechoseNum);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        lv3attack();
    }

    private void lv3attack()
    {
        //randommovechose();

        if (randommovechoseNum == 0)    //randommovechoseNum = 0
        {
            //DeshDown();
            DartAtk();
        }
        else
        {
            DartAtk();
        }
    }

    private void DeshDown()
    {

        float dist = Vector3.Distance(playerTransform.transform.position, transform.position);
        if (lv3boss.transform.position.y <= -3)
        {
            transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y + 5);
            print("up");
        }
        atk0timer += Time.deltaTime;
        if (atk0timer >= atk0cd)
        {
            atk0timer = 0;

            float distdash = Vector3.Distance(player.transform.position, transform.position);

            if (distdash > attackrange && lv3boss.transform.position.y >= -4.5)
            {
                transform.Translate(Vector3.down * dashspeed * Time.deltaTime);
                
            }
            Vector2 direction = player.transform.position - transform.position;
        }

    }

    private void DartAtk()
    {
        atk1timer += Time.deltaTime;
        if (atk1timer >= atk1cd)
        {
            atk1timer = 0;
            Instantiate(dartPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    //隨機數字
    private void randommovechose()
    {
        timer += Time.deltaTime;
        if (timer >= cd)
        {
            timer = 0;

            randommovechoseNum = Random.Range(0, 2);
            print(randommovechoseNum);
        }
    }
    

    /*IEnumerator Move()
    {

        while (move)  //移動到目標點停止移動
        {
            Vector3 targetPos = target.transform.position;

            //始終讓他朝著目標  
            this.transform.LookAt(targetPos);

            //計算弧線中的夾角  
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * rotationAngle;
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
            if (currentDist < 0.5f)
                move = true;
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
        while (!move)
        {
            Vector3 targetPos = target2.transform.position;

            //始終讓他朝著目標  
            this.transform.LookAt(targetPos);

            //計算弧線中的夾角
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * rotationAngle;
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
            if (currentDist < 0.5f)
                move = false;
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
    }
    */
    /*
     

    public class MoveTest : MonoBehaviour
    {
        public GameObject target;   //要到達的目標
        public float speed = 10;    //速度  
        public int rotationAngle = 60;
        private float distanceToTarget;   //兩者之間的距離 
        private bool move = true;
        public GameObject target2;

        void Start()
        {
            //計算兩者之間的距離  
            distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {

            while (move)  //移動到目標點停止移動
            {
                Vector3 targetPos = target.transform.position;

                //始終讓他朝著目標  
                this.transform.LookAt(targetPos);

                //計算弧線中的夾角  
                float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * rotationAngle;
                this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
                float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
                if (currentDist < 0.5f)
                    move = true;
                this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
                yield return null;
            }
            while(!move)
            {
                Vector3 targetPos = target2.transform.position;

                //始終讓他朝著目標  
                this.transform.LookAt(targetPos);

                //計算弧線中的夾角
                float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * rotationAngle;
                this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
                float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
                if (currentDist < 0.5f)
                    move = false;
                this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
                yield return null;
            }
        }

    }
     
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWithTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (位置 == 偵測的玩家位置)
        {
            執行衝刺腳本
        }
        if (執行衝刺腳本) ;
        {
            if (標籤 == "玩家") ;
            {
                hp.GetComponent<HP>().LoseLife(); //執行扣血腳本
            }
        }
        */
}
