using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement Settings")]
	public float moveSpeed = 5f;

	[Header("Jump Settings")]
	public float jumpForce = 10f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float groundCheckRadius = 0.2f;

	private Rigidbody2D rb;
	private bool isGrounded;
	public float isRight;

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
			isRight = 1;
		}
		else if (moveInput < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
			isRight = -1;
		}

		// Jump
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		if (Input.GetKeyDown(KeyCode.W) && isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}
}
