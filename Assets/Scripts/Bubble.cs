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
		if (gameObject.transform.localScale.x < 2 && gameObject.transform.localScale.y < 2)
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
		Debug.Log("hevele huvele");
		if (other.gameObject.tag == "enemy")
		{
			enemy = other.gameObject;
			isfly = true;
			Debug.Log(enemy.name + "seçildi");
		}

	}
}
