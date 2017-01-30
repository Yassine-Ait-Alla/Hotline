using UnityEngine;
using System.Collections;

public class bullet2 : MonoBehaviour
{
	private Vector3			target;
	private Vector3			pozycja;
	private float			AngleDeg;
	private float			AngleRad;

	public int Dist_o;
	private int Dist_t;

	private int p2 (float val) {
		return (Mathf.RoundToInt(val * val));
	}

	void Start ()
	{
		//ORIENTER PLAYER VERS LA SOURIE
		pozycja = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		target = transform.position;
		AngleRad = Mathf.Atan2(pozycja.y - transform.position.y, pozycja.x - transform.position.x);
		AngleDeg = (180 / Mathf.PI) * AngleRad;
	}

	void Update ()
	{
		//IGNORE LE COLLIDER DU TIREUR
		Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.colli.GetComponent<Collider2D>());
		Shoot();
		Dist_t = Mathf.Abs (Mathf.RoundToInt (Mathf.Sqrt (p2 (transform.position.x) + p2 (transform.position.y)) - Mathf.Sqrt (p2 (target.x) + p2 (target.y))));
		if (Dist_t >= Dist_o)
			Destroy (this.gameObject);
		//target = transform.position;
	}

	private void		Shoot()
	{
			//ROTATION -90 deg
		if (this.name == "punchBullet(Clone)" || this.name == "rocketBullet(Clone)" || this.name == "shotgunBullet(Clone)" )
		{
			this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg - 6));
			transform.Translate(Vector2.right * 7 *Time.deltaTime);
		}
		else if (this.name == "saberBullet(Clone)")
		{
			this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg - 6));
			transform.position = Vector3.MoveTowards(transform.position, player.targetZone, 0.1f);
		}
		else//COMPORTEMENT PROJECTILE NORMAL
		{
			this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));
			transform.Translate(Vector2.down * 7 *Time.deltaTime);
		}
	}

	private void		OnCollisionEnter2D(Collision2D col)
	{
		Destroy(this.gameObject);
	}
}




