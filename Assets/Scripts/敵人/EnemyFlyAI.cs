using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyAI : Enemy
{
    public float speed;
    public float radius;
    
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
    }
}
