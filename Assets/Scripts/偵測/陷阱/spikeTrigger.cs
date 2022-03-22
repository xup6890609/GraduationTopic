using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTrigger : MonoBehaviour
{
    public float destroyTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    if (collision.gameObject.tag == "Trap")
    {
        hp.GetComponent<HP>().LoseLife();
    }
    */
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"    other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            GetComponent<HP>().LoseLife();
        }
    }
    */
}
