using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalkan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
