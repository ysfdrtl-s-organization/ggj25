using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
	//zipkin prefab� eklencek 
	public GameObject mizrak;
	public GameObject bab�lgun;
	public GameObject ebab�l;
	//ba�lant� yap�lcak
	public PlayerMovement pm;
	public float force;
	//bubble prefab� eklencek
	public GameObject BubblePre;
	//spawn point
	public Transform weaponSpawn;
	private float bcooldown = 0f;
	private float mcooldown = 0f;
	private float ecooldown = 0f;

	int s = 0;

	private void Start()
	{
		mizrak.SetActive(true);
		bab�lgun.SetActive(false);
		ebab�l.SetActive(false);
	}

	private void Update()
	{
		bcooldown -= Time.deltaTime;
		mcooldown -= Time.deltaTime;
		ecooldown -= Time.deltaTime;
		//iki tip silah var 
		if (Input.GetKeyDown(KeyCode.Q))
		{
			s = 1 - s;
		}
		switch (s)
		{
			case 0:
				//1 z�pk�n ama m�zrak
				mizrak.SetActive(true);
				bab�lgun.SetActive(false);
				if (Input.GetKeyDown(KeyCode.Space) && mcooldown < 0f)
				{
					mizrak.transform.position += new Vector3(pm.isRigth / 2f, 0f, 0f);
					mizrak.GetComponent<BoxCollider2D>().enabled = true;
					Invoke("ZipkinGeri", 0.5f);
					mcooldown = 1f;
				}
				break;
			case 1:
				//2 balon tabancas�
				bab�lgun.SetActive(true);
				mizrak.SetActive(false);
				if (Input.GetKeyDown(KeyCode.Space) && bcooldown < 0f)
				{
					GameObject Bubble = Instantiate(BubblePre, weaponSpawn.position, weaponSpawn.rotation);
					Rigidbody2D rb = Bubble.GetComponent<Rigidbody2D>();
					rb.AddForce(new Vector2(pm.isRigth, 0f) * force, ForceMode2D.Impulse);
					bcooldown = 1f;
					Destroy(Bubble, 2f);
				}
				break;
		}
        if (Input.GetKeyDown(KeyCode.R) && ecooldown < 0f)
        {
			ebab�l.SetActive(true);
			ecooldown = 5f;
			Invoke("KalkanKapa", 2f);
        }
    }

	private void ZipkinGeri()
	{
		mizrak.transform.position = weaponSpawn.position;
		mizrak.GetComponent<BoxCollider2D>().enabled = false;
	}

	private void KalkanKapa()
	{		
		ebab�l.SetActive(false);
	}
}
