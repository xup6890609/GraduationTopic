using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private float bounce = 20f;         //跳躍初始值

    [Header("音效")]
    public AudioSource bouncingAudio;       //跳躍音效

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce , ForceMode2D.Impulse);
            bouncingAudio.Play();

        }
    }
}
