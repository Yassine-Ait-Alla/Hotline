using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {

	private GameObject					john;
	private GameObject					drop;

	public GameObject[]					Pdrop = new GameObject[6];
	public static Vector3				target;
	public static Vector3				targetZone;
	public List<shoot>					shoots = new List<shoot>();
	public static bool					alive = true;
	public static Transform				colli;
	public static bool					armed = false;
	public static bool					die = false;
	private int							haha = 40;
	public static  int					weapon;
	private AudioSource					son;
	public AudioSource					youLoose;
	public AudioSource					reload;


	private void Start ()
	{
		targetZone = transform.GetChild(6).transform.position;
		john = GameObject.Find("rambo");
		colli = this.transform;
		son = GetComponent<AudioSource>();
	}

	private void Awake () {
		alive = true;
		die = false;
		armed = false;
	}

	private void FixedUpdate ()
	{
		Die();
		target = transform.position;

		targetZone = transform.GetChild(6).transform.position;

		if (Input.GetMouseButtonDown(1) && armed)
		{
			drop = (GameObject)GameObject.Instantiate(Pdrop[weapon], transform.GetChild(6).transform.position, Quaternion.identity);
			this.transform.GetChild(weapon).gameObject.SetActive(false);
			armed = false;
			Debug.Log(armed);
			Debug.Log (drop);
		}

		if (Input.GetKey ("d") || Input.GetKey ("s") || Input.GetKey ("w") || Input.GetKey ("a"))
			this.transform.GetChild(7).GetComponent<Animator>().Play("run");
		else
			this.transform.GetChild(7).GetComponent<Animator>().Play("stay");
		if (Input.GetKey ("d"))
			john.transform.Translate(Vector2.right * (5 * Time.deltaTime), Space.World);
		if (Input.GetKey ("a"))
			john.transform.Translate(Vector2.left * (5 * Time.deltaTime), Space.World);
		if (Input.GetKey ("w"))
			john.transform.Translate(Vector2.up * (5 * Time.deltaTime), Space.World);
		if (Input.GetKey ("s"))
			john.transform.Translate(Vector2.down * (5 * Time.deltaTime), Space.World);

		Vector3 pozycja = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float AngleRad = Mathf.Atan2(pozycja.y - transform.position.y, pozycja.x - transform.position.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		if (alive == true)
			this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));
	}
		
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "badBullet")
		{
			son.Play();
			die = true;
			alive = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log(armed);
		if (col.tag == "loot" && armed == false)
		{
			reload.Play();
			Destroy(col.gameObject);
			for (int i=0; i<6; i++)
			{
				this.transform.GetChild(i).gameObject.SetActive(false);
			}
			foreach (shoot s in shoots)
			{
				if (col.name == s.name || s.name + "(Clone)" == col.name)
				{
					this.transform.GetChild(shoots.IndexOf(s)).gameObject.SetActive(true);
					weapon = shoots.IndexOf(s);
				}
			}
			armed = true;
		}
	}
	
	private void	Die()
	{
		if (die == true)
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * 1850);
			haha--;
		}
		if (haha < 1)
		{
			youLoose.Play();
			enemy.nbEnnemi = 0;
			Destroy(gameObject);
		}
	}
}
