using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
	//zipkin prefab� eklencek 
	public GameObject mizrak;
	//ba�lant� yap�lcak
	public PlayerMovement pm;
	public float force;
	//bubble prefab� eklencek
	public GameObject BubblePre;
	//spawn point
	public Transform weaponSpawn;
	private float bcooldown = 0f;
	private float mcooldown = 0f;

	int s = 0;

	private void Update()
	{
		bcooldown -= Time.deltaTime;
		mcooldown -= Time.deltaTime;
		//iki tip silah var 
		if (Input.GetKeyDown(KeyCode.Q))
		{
			s = 1 - s;
			Debug.Log(s);
		}
		switch (s)
		{
			case 0:
				//1 z�pk�n ama m�zrak
				if (Input.GetKeyDown(KeyCode.Space) && mcooldown < 0f)
				{
					mizrak.SetActive(true);
					mcooldown = 0f;
				}
				break;
			case 1:
				//2 balon tabancas�
				if (Input.GetKeyDown(KeyCode.Space) && bcooldown < 0f)
				{
					GameObject Bubble = Instantiate(BubblePre, weaponSpawn.position, weaponSpawn.rotation);
					Rigidbody2D rb = Bubble.GetComponent<Rigidbody2D>();
					rb.AddForce(new Vector2(pm.isRight, 0f) * force, ForceMode2D.Impulse);
					bcooldown = 1f;
					Destroy(Bubble, 2f);
				}
				break;
		}
	}
}
