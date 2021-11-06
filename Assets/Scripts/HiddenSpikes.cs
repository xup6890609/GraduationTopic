using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpikes : MonoBehaviour
{
    public int damge;
    //public HP hp;
    public GameObject spikeTrigger;
    public float time;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //hp = GameObject.FindGameObjectsWithTag("Player").GetComponent<HP>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"/*other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D"*/)
        {
            
            StartCoroutine(SpikeAttack());
        }
    }

    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");
        Instantiate(spikeTrigger, transform.position, Quaternion.identity);
    }
}
