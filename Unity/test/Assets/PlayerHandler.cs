using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	private GameObject hud = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hud == null) 
		{
			if (GameObject.FindGameObjectsWithTag("HUD") != null)
			{
				hud = GameObject.FindGameObjectWithTag("HUD");
		
			}
		}
	}

	public void hurted()
	{

		hud.SendMessage ("healthDown", 10);
		audio.Play ();
	}

}
