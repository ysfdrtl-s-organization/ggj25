using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardedEnemy : MonoBehaviour
{
	public bool hasbubble;
	float cooldown;
	float force;

	public Transform spawn;
	public GameObject prefab;
	private SpriteRenderer ss;
	private Transform enemy;

	private void Start()
	{
		ss = GetComponent<SpriteRenderer>();
		enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	private void Update()
	{
		if (gameObject.tag == "guardedEnemy")
		{
			cooldown -= Time.deltaTime;
			ss.flipX = (enemy.position.x - transform.position.x) < 0f;
			if (cooldown < 0f)
			{
				shoot();
				cooldown = 3f;
			}
		}
	}

	private void shoot()
	{
		GameObject bullet = Instantiate(prefab, spawn.position, spawn.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		if (ss.flipX) force = -5f;
		else force = 5f;
		rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
	}
}
