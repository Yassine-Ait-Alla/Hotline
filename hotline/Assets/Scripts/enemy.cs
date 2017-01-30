using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour
{
	[HideInInspector]
	public bool			agro = false;
	private Vector3				target;
	private float				angle;
	private IEnumerator			routine = null;
	private GameObject			fire;
	public GameObject			Pfire;
	public static bool			bastos = false;
	[HideInInspector]
	public bool			dead = false;
	private int					haha = 30;
	private AudioSource			son;
	public static int nbEnnemi = 0;

	private void Start ()
	{
		target = transform.position;
		nbEnnemi += 1;
		son = GetComponent<AudioSource>();
	}

	private void Update ()
	{
		if (this.tag == "patrol" && agro == false)
		{
			if (transform.localPosition.x > (target.x + 3.5f))
			{
				transform.Rotate(new Vector3(0, 0, -90));
			}
			if (transform.localPosition.x < (target.x - 3.5f))
			{
				transform.Rotate(new Vector3(0, 0, 90));
			}
			transform.Translate(Vector2.down * Time.deltaTime * 2);
		}
		if (!player.alive)
			agro = false;
		if (agro)
		{
			if (routine == null)
			{
				routine = shoot();
				StartCoroutine(routine);
			}
			
			this.transform.GetChild(2).gameObject.SetActive(true);
			target = player.target;
			Vector3 dir = target - transform.position;
			angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			transform.Translate(Vector3.down * Time.deltaTime * 1.2f);
		}
		Die();
	}

	IEnumerator			shoot()
	{
		if (!dead) {
			while (player.alive) {
				fire = (GameObject)GameObject.Instantiate (Pfire, transform.position, Quaternion.identity);
				Physics2D.IgnoreCollision (fire.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
				yield return new WaitForSeconds (1);
			}
		}
	}

	private void Die()
	{
		if (dead == true)
		{
			Debug.Log("WHAT");
			transform.Rotate(Vector3.forward * Time.deltaTime * 1850);
			haha--;
		}
		if (haha < 1)
		{
			nbEnnemi -= 1;
			Destroy(gameObject);
		}
	}

	private void		OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "bullet")
		{
			son.Play();
			dead = true;
			agro = false;
		}
	}
}