using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float up;
    public float clampLeft;
    public float clampRight;
    public float clampUp;

    private float cameraX;
    private float cameraY;

    public Vector2 limit = new Vector2(0, 2f);

    // Use this for initialization
    void Start()
    {
        cameraX = transform.position.x;
        cameraY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < clampRight)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > clampLeft)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.UpArrow)) && transform.position.y > clampUp)
        {
            transform.Translate(new Vector3( 0,up *Time.deltaTime,0));
            Debug.Log(cameraX);
            Debug.Log(cameraY);
        }
    }
}
