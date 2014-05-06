using UnityEngine;
using System.Collections;

public class  hudHandler : MonoBehaviour {

	public static bool invincible = false;
    private int intScore = 0;
    private int intHealth = 100;
	private float floatEnergy = 0;
	private int intEnergy;
    public GUIText health;
    public GUIText score;
	public GUIText energy;


	IEnumerator invincibility ()
	{
		invincible = true;
		while (floatEnergy > 0.5f) 
		{
			Debug.Log (" You are invincible for now..");

			useEnergy (30);

			yield return null;
		}
		invincible = false;

	}


	void Start () {
        health.text = intHealth.ToString();
        score.text = intScore.ToString();
		energy.text = floatEnergy.ToString ();
		invincible = false;
	}
	
	// Update is called once per frame
	void Update () 
    {	

		if (Input.GetKeyDown(KeyCode.A) && invincible == false && floatEnergy > 100) 
		{
			StartCoroutine (invincibility());
		}

		Debug.Log (invincible);
		int intEnergy = (int)floatEnergy;
		
		
		if (intEnergy > 150) 
		{
			loseEnergy (intEnergy - 150);
		}
		
		if (intEnergy < 0) 
		{
			intEnergy = 0;
		}
		
		if (intHealth > 100) 
		{ 
			intHealth = 100;
		}
		
		if (intHealth < 0) 
		{ 
			intHealth = 0;
		}
		
		health.text = intHealth.ToString ();
		score.text = intScore.ToString ();
		energy.text = intEnergy.ToString ();
		
		if (intEnergy < 100) 
		{
			stockEnergy (Time.deltaTime * 3);
		}
		if (intEnergy >= 100) 
		{
			stockEnergy (Time.deltaTime* 1.5f);
		}

	
	}

    public void pointInc (int x)
    {
        intScore += x;
    }
	public void healthDown(int x)
	{	
		intHealth -= x;
	}
	public void healthUp(int x)
	{
		intHealth += x;
	}
	public void stockEnergy (float x)
	{
		floatEnergy += x;
	}
	public void useEnergy (float x)
	{
		floatEnergy -= x*Time.deltaTime;
	}
	public void loseEnergy (float x)
	{	
		floatEnergy -= x;
	}
	public  int getHealth()
	{
		return intHealth;
	}
	
	public int getScore()
	{
		return intScore;
	}
	public float getEnergy()
	{
		return floatEnergy;
	}
    public void setHealth(int x)
	{
		intHealth = x;
	}
	public void setScore(int x)
	{
		intScore = x;
	}
	public bool getInvincible()
	{
		return invincible;
	}
	public int getIntEnergy ()
	{
		return intEnergy;
	}


}
