using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3BOSSnew : MonoBehaviour
{

    public GameObject KnifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Instantiate(KnifePrefab, this.gameObject.transform.position, Quaternion.identity);
    }

    

}
