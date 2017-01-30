using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAnimation : MonoBehaviour
{

	private		float		size = 0.02f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localScale += new Vector3(size, size, 0);
		if (transform.localScale.x > 3)
			transform.localScale = new Vector3(size, size, 0);
	}
}
