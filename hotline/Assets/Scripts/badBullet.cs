using UnityEngine;
using System.Collections;

/*********************************************************
 *
 * 				ENEMY BULLET
 *
 * *******************************************************/

public class badBullet : MonoBehaviour {

	//private Vector3				target =  player.target;
	//private AudioSource	son;

	private Vector3			pozycja;
	private float			AngleDeg;
	private float			AngleRad;

	void Start ()
	{
		pozycja = player.target;
		AngleRad = Mathf.Atan2(pozycja.y - transform.position.y, pozycja.x - transform.position.x);
		AngleDeg = (180 / Mathf.PI) * AngleRad;
	}

	void Update ()
	{

		this.transform.rotation = Quaternion.Euler(0, 0, (AngleDeg + 84));
		transform.Translate(Vector2.down * 7 *Time.deltaTime);

	}

	private void		OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log(col.gameObject.name);
		//if (col.gameObject.name != "body" && col.gameObject.name != "enemy")
			Destroy(this.gameObject);
	}
}

