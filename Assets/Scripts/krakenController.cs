using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krakenController : MonoBehaviour
{

	public GameObject krakenHead;
	public int health = 5;
	public List<GameObject> TentacleLR;
	public List<GameObject> TentacleUP;
	public List<GameObject> TentacleHalf;
	//bu ilk atack için konumlar      çift sayýlar dýþarý       tek yasýlar içeri temsil ediyo
	public List<Vector2> vector2LR;
	//attack 2 yukarý aþþa            çift sayýlar dýþarý       tek yasýlar içeri temsil ediyo
	public List<Vector2> vector2UP;
	// attack3 yarým harita
	public List<Vector2> vector2Half;
	private int rand;
	private int count;
	private bool isgo = true;
	public bool devam = true;



	public int atackRoutine;

	private void Start()
	{
	}

	private void Update()
	{
		if (devam)
		{
			gameObject.GetComponent<Collider2D>().enabled = false;

			switch (atackRoutine)
			{
				case 0:
					attack1();
					break;
				case 1:
					attack2();
					break;
				case 2:
					attack3();
					break;

			}
		}
		else
		{
			krakenHead.GetComponent<Collider2D>().enabled = true;
		}
		if (health == 0)
		{
			Destroy(krakenHead);
		}
	}

	private void attack1()
	{
		//saðdan ve soldan vurma
		Vector2 tmp;
		if (isgo)
		{
			tmp = vector2LR[rand * 2 + 1];
		}
		else
		{
			tmp = vector2LR[rand * 2];
		}

		if (Vector3.Distance(TentacleLR[rand].transform.position, tmp) < 0.2f)
		{
			isgo = !isgo;
			if (isgo)
			{
				rand = (rand + 1) % 4;
				count++;
				if (count == 4)
				{
					count = 0;
					atackRoutine = 1;
					rand = 0;
					devam = false;
				}
			}
		}
		TentacleLR[rand].transform.position = Vector3.Lerp(TentacleLR[rand].transform.position, tmp, 0.02f);


	}
	private void attack2()
	{
		//yerden fýrlama
		Vector2 tmp;
		if (isgo)
		{
			tmp = vector2UP[rand * 2 + 1];
		}
		else
		{
			tmp = vector2UP[rand * 2];
		}

		if (Vector3.Distance(TentacleUP[rand].transform.position, tmp) < 0.2f)
		{
			isgo = !isgo;
			if (isgo)
			{
				rand = (rand + 1) % 5;
				count++;
				if (count == 5)
				{
					count = 0;
					atackRoutine = 2;
					devam = false;
				}
			}
		}
		TentacleUP[rand].transform.position = Vector3.Lerp(TentacleUP[rand].transform.position, tmp, 0.04f);
	}
	private void attack3()
	{
		// yarým harita
		Vector2 tmp;
		if (isgo)
		{
			tmp = vector2Half[rand * 2 + 1];
		}
		else
		{
			tmp = vector2Half[rand * 2];
		}

		if (Vector3.Distance(TentacleHalf[rand].transform.position, tmp) < 0.1f)
		{
			isgo = !isgo;
			if (isgo)
			{
				rand = (rand + 1) % 2;
				count++;
				if (count == 4)
				{
					count = 0;
					atackRoutine = 0;
					devam = false;
				}
			}
		}
		TentacleHalf[rand].transform.position = Vector3.Lerp(TentacleHalf[rand].transform.position, tmp, 0.01f);
	}
	private void devvvam()
	{
		devam = true;
	}
}
