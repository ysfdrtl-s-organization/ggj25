using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public int Health = 3;
    public GameObject paluk1;
    public GameObject paluk2;
    public GameObject paluk3;
    public GameObject head;
    public Text gameoverText;

    private Rigidbody2D rb;
    void Start()
    {
        gameoverText.text = null;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" || collision.tag == "tuzak")
        {
            Health--;
            if (Health == 2)
            {
                paluk1.SetActive(false);
            }
            if (Health == 1)
            {
                paluk2.SetActive(false);
            }
            if (Health == 0)
            {
                head.SetActive(false);
                paluk3.SetActive(false);
                gameoverText.text = "GAME OVER";
                Time.timeScale = 0.0f;
            }
        }
        if (collision.tag == "mayýn")
        {
            Destroy(collision.gameObject);
            Health--;
            if (Health == 2)
            {
                paluk1.SetActive(false);
            }
            if (Health == 1)
            {
                paluk2.SetActive(false);
            }
            if (Health == 0)
            {
                head.SetActive(false);
                paluk3.SetActive(false);
                gameoverText.text = "GAME OVER";
                Time.timeScale = 0.0f;
            }
        }

    }
}
