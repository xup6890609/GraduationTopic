using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject final;

    public Text textCount;

    public int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "door")
        {
            final.SetActive(true);
        }

        if (collision.tag == "道具")
        {
            Destroy(collision.gameObject);

            count++;
            textCount.text = "道具數量:" + count;
        }

        if (collision.tag == "npc")
        {
            Destroy(collision.gameObject);

        }
    }

}
