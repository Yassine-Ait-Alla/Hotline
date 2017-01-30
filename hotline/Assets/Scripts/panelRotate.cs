using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelRotate : MonoBehaviour {

	
	private bool		right = true;
	private float		rot;
	void Start () 
	{
		rot = 2 * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (right)
		{
			transform.Rotate(Vector3.forward * rot);
			if (transform.rotation.z > 0.06f)
				right = false;
		}
		else
		{
			transform.Rotate(Vector3.forward * (-rot));
			if (transform.rotation.z < -0.06f)
				right = true;
		}

	}
}
