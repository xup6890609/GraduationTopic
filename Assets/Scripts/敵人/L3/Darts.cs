using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darts : MonoBehaviour
{
    private Rigidbody2D dartRig;
    public float dartspeed = 900f;

    /*public Transform sunrise;
    public Transform sunset;
    public float journeyTime = 1.0f;
    private float startTime;*/

    /*
    public GameObject target;   //要到達的目標
    public float speed = 10;    //速度  
    public int rotationAngle = 60;
    private float distanceToTarget;   //兩者之間的距離 
    private bool move = true;
    public GameObject target2;
    */

    private void Awake()
    {
        dartRig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*計算兩者之間的距離  
         = Vector3.Distance(this.transform.position, target.transform.position);
        StartCoroutine(Move());*/

        //startTime = Time.time;

        AddStartingForce();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*// The center of the arc
        Vector3 center = (sunrise.position + sunset.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, -3, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;*/
    }

    private void FixedUpdate()
    {
        
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        dartRig.AddForce(direction * this.dartspeed);
    }

    void DartsMove()
    {
        
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
}
