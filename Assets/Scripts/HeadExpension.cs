using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class HeadExension : MonoBehaviour
{
    public GameObject head;
    private Rigidbody2D rb;
    private float coolDown = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && coolDown < 0)
        {
            coolDown = 10f;
            head.transform.localScale = new Vector3(2,2,2);
            rb.gravityScale = -0000.1f;
            Invoke("notFly",5);
        }
    } 

    private void notFly()
    {
        head.transform.localScale = new Vector3(1,1,1) ;
        rb.gravityScale = 1f;
    }
}
