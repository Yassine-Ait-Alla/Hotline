using UnityEngine;
using System.Collections;

public class enemyBase : MonoBehaviour
{
	private enemy en;

	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "rambo")
		{
			en = GetComponent<enemy> ();
			en.agro = true;
		}
	}
}
