using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public bool setActive = false;
    public GameObject Dialog;
    public GameObject Player;
    public GameObject show;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] bool dontMove;
    [SerializeField] bool canMove;

    private void Start()
    {
        dontMove = false;
        canMove = true;
        CantMove();
        CanMove();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            setActive = true;
            Dialog.SetActive(true);
        }
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            setActive = false;
            CanMove();
            Destroy(show.gameObject);
        }
        if (setActive == true)
        {
            CantMove();
        }
    }
    void CantMove()
    {
        dontMove = true;
        canMove = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
    void CanMove()
    {
        dontMove = false;
        canMove = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
