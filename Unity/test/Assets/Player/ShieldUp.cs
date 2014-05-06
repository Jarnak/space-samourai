using UnityEngine;
using System.Collections;

public class ShieldUp : MonoBehaviour {

	private hudHandler hud = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hud == null) 
		{
			if (GameObject.FindGameObjectsWithTag("HUD") != null)
			{
				hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<hudHandler>();
				
			}
		}

		if (hud.getInvincible ()) 
		{
			this.renderer.enabled = true;
		} 
		else 
		{
			this.renderer.enabled = false;
		}
	}
}
