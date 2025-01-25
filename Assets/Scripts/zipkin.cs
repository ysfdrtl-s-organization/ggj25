using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zipkin : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision != null)
		{
			if (collision.tag == "enemy")
			{
				Destroy(collision.gameObject);
			} 
			if (collision.tag == "guardedEnemy")
			{
				guardedEnemy ge = collision.GetComponent<guardedEnemy>();
				if (ge.hasbubble)
				{
					ge.hasbubble = false;
				}
				else
				{
					Destroy(collision.gameObject);
				}
			}
			if (collision.tag == "kraken")
			{
				krakenController kk = collision.GetComponent<krakenController>();
				kk.health--;
				kk.devam = true;
			}
		}
	}
}
