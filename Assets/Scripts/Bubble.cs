using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
	bool isfly = false;
	Rigidbody2D rb;
	GameObject enemy;
	float x = 0;
	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	private void FixedUpdate()
	{
		if (gameObject.transform.localScale.x < 0.4f && gameObject.transform.localScale.y < 0.4f)
		{
			gameObject.transform.localScale *= 1.08f;
		}

		if (!isfly)
		{
			x = Mathf.Lerp(x, -1, 0.1f);
			rb.gravityScale = x;
		}

		if (isfly)
		{
			enemy.transform.position = Vector3.Lerp(enemy.transform.position, this.transform.position, 0.7f);
			rb.gravityScale = -2;
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "enemy")
		{
			enemy = other.gameObject;
			Destroy(enemy, 3f);
			isfly = true;
		}

	}
}
