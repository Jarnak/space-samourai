using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
private hudHandler hud = null;
public AudioClip hurtedSound;
public AudioClip shielded;
private CapsuleCollider capsule;


	void Start () 
	{
		capsule = (CapsuleCollider)GetComponent(typeof(CapsuleCollider));
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
			capsule.radius = 1.6f;
		} 
		else 
		{
			capsule.radius = 0.4f;
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		if (hud.getInvincible () && coll.tag == "ennemy") 
		{
			audio.clip = shielded;
			audio.Play();
			Destroy (coll.gameObject);
			hud.pointInc(50);
		}
	}

	public void hurted()
	{
		if (!hud.getInvincible ()) 
		{
			hud.healthDown(10);
			hud.loseEnergy (8);
			audio.clip = hurtedSound;
			audio.Play ();
		}

				 
		else 
		{
			hud.pointInc(10);
			audio.clip = shielded;
			audio.Play ();
		}
	}

	public void healed()
	{
		hud.SendMessage ("healthUp", 30);
	}

}
