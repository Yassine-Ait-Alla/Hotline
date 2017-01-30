using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera : MonoBehaviour
{

	private void Update () 
	{
		if (player.alive == true)
		{
			transform.GetChild(1).gameObject.SetActive(false);
			transform.position = new Vector3 (player.target.x, player.target.y, -10);
		}
		else
		{
			transform.GetChild(1).gameObject.SetActive(true);
			transform.GetChild(2).gameObject.SetActive(false);
		}

		if (enemy.nbEnnemi == 0 && player.alive)
		{
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(true);
		}
		else
			transform.GetChild(2).gameObject.SetActive(false);

	}
}
