using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
private hudHandler hud = null;
public AudioClip hurtedSound;
public AudioClip shielded;

private AudioSource shieldHurtSound;
private AudioSource battement;
private AudioSource[] tabSource;

bool lowLife = false; 
private CapsuleCollider capsule;



	void Start () 
	{
		capsule = (CapsuleCollider)GetComponent(typeof(CapsuleCollider));
        tabSource = GetComponents<AudioSource>();
        shieldHurtSound = tabSource[0];
        battement = tabSource[1];
        
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

        if (!lowLife && hud.getHealth() <= 20)
        {
            battement.Play();
            lowLife = true;
        }

        if (hud.getHealth() > 20)
        {
            battement.Stop();
            lowLife = false;

        }
	}

	void OnTriggerEnter (Collider coll)
	{
		if (hud.getInvincible () && coll.tag == "ennemy") 
		{
            shieldHurtSound.clip = shielded;
            shieldHurtSound.Play();
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
            shieldHurtSound.clip = hurtedSound;
			audio.Play ();
		}

				 
		else 
		{
			hud.pointInc(10);
			shieldHurtSound.clip = shielded;
			audio.Play ();
		}
	}

	public void healed()
	{
		hud.SendMessage ("healthUp", 30);
	}

}
