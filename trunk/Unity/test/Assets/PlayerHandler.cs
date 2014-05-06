using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
private hudHandler hud = null;
public AudioClip hurtedSound;
public AudioClip shielded;

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
				hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<hudHandler>();
		
			}
		}
	}

	public void hurted()
	{
		if (!hud.getInvincible ()) 
		{
			hud.healthDown(10);
			hud.loseEnergy (3);
			audio.clip = hurtedSound;
			audio.Play ();
		}

				 
		else 
		{
			audio.clip = shielded;
			audio.Play ();
		}
	}

	public void healed()
	{
		hud.SendMessage ("healthUp", 30);
	}

}
