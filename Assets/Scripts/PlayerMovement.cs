using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float isRigth;

    private Rigidbody2D rb;
    private bool isGrounded;

    public GameObject head;
    private float coolDown = 0f;
    private float coolUp = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the character
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRigth = 1;
        }

        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRigth = -1;
        }

        RaycastHit2D hit2 = Physics2D.Raycast(head.transform.position, Vector2.up, 0.3f, groundLayer);
        // Jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);     
            coolUp = 0.25f;
        }

        coolDown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && coolDown < 0)
        {
            coolDown = 10f;
            coolUp = 2f;
            head.transform.localScale = new Vector3(2, 2, 2);
            rb.gravityScale = -0.125f;
            Invoke("notFly", 3.5f);
        }

        if (!isGrounded)
        {
            if (hit2.collider != null)
            {
                if (hit2.collider.tag == "platform")
                {
                    gameObject.GetComponent<Collider2D>().isTrigger = true;
                    Invoke("triggerFalse", coolUp);
                }
            }
        }



        // aþaðý düþme
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayer);
        
        if (hit.collider != null)
        {
            if (hit.collider.tag == "platform" && Input.GetKeyDown(KeyCode.S))
            {
                gameObject.GetComponent<Collider2D>().isTrigger = true;
                coolUp = 0f;
                Invoke("triggerFalse",0.5f);
            }
        }

        
    }

    private void triggerFalse()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }

    private void notFly()
    {
        head.transform.localScale = new Vector3(1, 1, 1);
        rb.gravityScale = 1f;
    }


}
