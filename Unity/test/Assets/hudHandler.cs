using UnityEngine;
using System.Collections;

public class  hudHandler : MonoBehaviour {

	public static bool invincible = false;
    private int intScore = 0;
    private int intHealth = 100;
	private float floatEnergy = 0;
	private int intEnergy;
    //public GUIText health;
    public GUIText score;
	//public GUIText energy;

    public Texture vert;
    public Texture rouge;
    public Texture jaune;
    public Texture gris;
    public Texture orange;
	public GameObject server;
	private DATA data;
    bool lowLife = false; 
	private bool withAndroid;

    // GUI variable

    private Rect healthRect;
    private Rect powerRect;

    private int jaugeWidth = 20;

    private int jaugeHeight;

    private int topIndent =  50;

    private int hIndent =50;

    GUIStyle style;
   
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
        //health.text = intHealth.ToString();
        score.text = intScore.ToString();
		//energy.text = floatEnergy.ToString ();
		invincible = false;
        jaugeHeight = Screen.height - 100;
		score.pixelOffset = new Vector2 (Screen.width / 2, Screen.height - 40 );
		withAndroid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>().withAndroid();
		server = GameObject.FindGameObjectWithTag("Server");
	}
	
	// Update is called once per frame
	void Update () 
    {	


		if (withAndroid) 
		{
			data = server.GetComponent<ServerHandler>().getData();
			//Debug.Log(data.shield);
			if ( data.shield && withAndroid && invincible == false && floatEnergy > 100)
			{
				StartCoroutine (invincibility());
			}
		}

		if (Input.GetKeyDown(KeyCode.A) && !withAndroid && invincible == false && floatEnergy > 100) 
		{
			StartCoroutine (invincibility());
		}
        
        if (!lowLife  && intHealth <=20)
        {
            audio.Play();
            lowLife = true;
        }

        if (intHealth > 20)
        {
            audio.Stop();
            lowLife = false;

        }




		//Debug.Log (invincible);
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
		
		//health.text = intHealth.ToString ();
		score.text = intScore.ToString ();
		//energy.text = intEnergy.ToString ();
		
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


        if (!lowLife)
        {
            GUI.Box(new Rect(hIndent, topIndent, jaugeWidth, jaugeHeight * intHealth/100), vert); 
        }
        else 
        {
            GUI.Box(new Rect(hIndent, topIndent, jaugeWidth, jaugeHeight * intHealth / 100), rouge);
        }
	
        if (floatEnergy < 100)
        {
            GUI.Box(new Rect(Screen.width - 2*hIndent, topIndent, jaugeWidth, jaugeHeight * floatEnergy / 150), gris); 
        }
        else
        {
            if (floatEnergy  == 150)
            {
                GUI.Box(new Rect(Screen.width - 2 * hIndent, topIndent, jaugeWidth, jaugeHeight * floatEnergy / 150), orange); 
            }
            else
            {
                GUI.Box(new Rect(Screen.width - 2 * hIndent, topIndent, jaugeWidth, jaugeHeight * floatEnergy / 150), jaune);
            }
        }
    }

}
