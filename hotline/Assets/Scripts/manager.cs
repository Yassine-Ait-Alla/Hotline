using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void		Exit()
	{
		Application.Quit ();
	}

	public void		Title()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void		charge()
	{
		SceneManager.LoadScene("Scene_3");
	}


	public void		charge2()
	{
		SceneManager.LoadScene("Scene_4");
	}
}
