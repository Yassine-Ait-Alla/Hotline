using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shoot : MonoBehaviour {



	private GameObject				fire;
	public GameObject				Pfire;
	public int[]					ammo = new int[6];
	public AudioSource				son;

	void Start ()
	{
		son = GetComponent<AudioSource>();
	}

	private void Update ()
	{
		if (player.armed)
			Camera.main.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>().text = ammo[player.weapon].ToString();
		else
			Camera.main.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>().text = "0";
		if (Input.GetMouseButtonDown(0) && player.armed)
		{
			if (ammo[player.weapon] > 0)
			{
				fire = (GameObject)GameObject.Instantiate(Pfire, transform.position, Quaternion.identity);
				ammo[player.weapon]--;
			}
			else
				son.Play();
		}
	}
}
