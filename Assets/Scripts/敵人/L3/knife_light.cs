using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife_light : MonoBehaviour
{
    //劍氣飛行速度
    [Header("飛行速度")]
    public float knifeSpeed;

    //劍氣本身
    [Header("劍氣本身")]
    public GameObject light;

    [Header("生成劍氣幾秒後刪除")]
    public int sec;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(light, sec);
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.position += new Vector3(knifeSpeed, 0, 0);
    }
}
