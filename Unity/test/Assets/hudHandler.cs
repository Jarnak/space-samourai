﻿using UnityEngine;
using System.Collections;

public class  hudHandler : MonoBehaviour {

	public static bool invincible = false;
    private int intScore = 0;
    private int intHealth = 100;
	private float floatEnergy = 0;
	private int intEnergy;
    private bool shieldReady = false;
    

    // Sound variable
    public AudioClip ShieldOff;
    public AudioClip ShieldUP;

    //public GUIText health;
    public GUIText score;
    private GUITexture health;
    private GUITexture energy;


	public GameObject server;
	private DATA data;
	private bool withAndroid;

    // GUI variable

//    private Rect healthRect;
//    private Rect powerRect;

    private int jaugeWidth = 40;

    private int jaugeHeight;

    private int topIndent =  50;
    private int leftIndent =50;
    private int healthTopIndent;
    private int healthLeftIndent;
    private int energyLeftIndent;
    private int energyTopIndent;

    public Texture vert;
    public Texture rouge;
    public Texture jaune;
    public Texture gris;
    public Texture orange;
   
	IEnumerator invincibility ()
	{
		invincible = true;
		while (floatEnergy > 1f) 
		{
			Debug.Log (" You are invincible for now..");

			useEnergy (30);

			yield return null;
		}
		invincible = false;

	}


	void Start () {
        
        // on recupère la hauteur de la jauge
        jaugeHeight =  Screen.height +- 100;
        healthTopIndent = Screen.height / 2 - topIndent;
        healthLeftIndent = -Screen.width / 2 + leftIndent;
        energyTopIndent = Screen.height / 2 - topIndent;
        energyLeftIndent = Screen.width / 2 - 2*leftIndent;
        
        // on iniitialise les affichages à l'écran
        score.text = intScore.ToString();
        health = GameObject.Find("Health").GetComponent<GUITexture>();
        energy = GameObject.Find("Energy").GetComponent<GUITexture>();
        health.pixelInset = new Rect( healthLeftIndent, healthTopIndent, jaugeWidth, -jaugeHeight);
        energy.pixelInset = new Rect(energyLeftIndent, energyTopIndent, jaugeWidth, -jaugeHeight);
        energy.texture = gris;
        health.texture = vert;

		invincible = false;
        jaugeHeight = Screen.height - 100;
		score.pixelOffset = new Vector2 (Screen.width / 2, Screen.height - 40 );
		withAndroid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>().withAndroid();
		server = GameObject.FindGameObjectWithTag("Server");
	}
	
	// Update is called once per frame
	void Update () 
    {	

        // on regarde si on doit activer l'invincibilité

        
		if (withAndroid) 
		{
            // si on est sous android, on récupère la feuille de données
			data = server.GetComponent<ServerHandler>().getData();
			
			if ( data.shield && withAndroid && invincible == false && floatEnergy > 100)
			{
				StartCoroutine (invincibility());
			}
		}

		if (Input.GetKeyDown(KeyCode.A) && !withAndroid && invincible == false && floatEnergy > 100) 
		{
			StartCoroutine (invincibility());
		}
        




        // on regarde si les différentes variables sont bien dans les bornes sinon on les remet a la borne
        
		int intEnergy = (int)floatEnergy;
		
		
		if (intEnergy > 150) 
		{
			intEnergy = 150;
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
		

        // on met à jour le score à l'écran

		score.text = intScore.ToString ();

        // on met à jour les jauge à l'écran 

        if (intHealth > 20)
        {
            health.texture = vert;
            health.pixelInset = new Rect(healthLeftIndent, healthTopIndent, jaugeWidth, -jaugeHeight * intHealth /100);
        }
        else
        {
            health.texture = rouge;
            health.pixelInset = new Rect(healthLeftIndent, healthTopIndent, jaugeWidth, -jaugeHeight * intHealth /100);
        }

        if (floatEnergy < 100)
        {
            energy.texture = gris;
            energy.pixelInset = new Rect(energyLeftIndent, energyTopIndent, jaugeWidth, -jaugeHeight * floatEnergy/150);
        }
        else
        {
            if (floatEnergy == 150)
            {
                energy.texture = orange;
                energy.pixelInset = new Rect(energyLeftIndent, energyTopIndent, jaugeWidth, -jaugeHeight * floatEnergy / 150);
            }
            else
            {
                energy.texture = jaune;
                energy.pixelInset = new Rect(energyLeftIndent, energyTopIndent, jaugeWidth, -jaugeHeight * floatEnergy / 150);
            }
        }

        // Execution dépendant de l'état de l'energie;

		if (intEnergy < 100) 
		{
			stockEnergy (Time.deltaTime * 3);
            if (shieldReady && !invincible)
            {
                shieldReady = false;
                audio.clip = ShieldOff;
                audio.Play();
            }
		}
		if (intEnergy >= 100) 
		{
			stockEnergy (Time.deltaTime* 1.5f);
            if (!shieldReady && !invincible)
            {
                audio.clip = ShieldUP;
                audio.Play();
                shieldReady = true;
            }
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
        if (floatEnergy + x > 150f)
            floatEnergy = 150;
        else
            floatEnergy += x;
	}
	public void useEnergy (float x)
	{
        if (floatEnergy - x * Time.deltaTime < 0)
            floatEnergy = 0;
        else
            floatEnergy -= x * Time.deltaTime;
	}
	public void loseEnergy (float x)
	{
        if (floatEnergy - x < 0)
            floatEnergy = 0;
        else floatEnergy -= x;
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

	void OnGUI()
	{



    }

}
