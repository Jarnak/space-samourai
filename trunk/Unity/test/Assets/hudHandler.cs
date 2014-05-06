using UnityEngine;
using System.Collections;

public class hudHandler : MonoBehaviour {

    private int intScore = 0;
    private int intHealth = 100;
    public GUIText health;
    public GUIText score;
	// Use this for initialization
	void Start () {
        health.text = intHealth.ToString();
        score.text = intScore.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {	
		if (intHealth < 0) 
		{
			intHealth = 0;		
		}
        health.text = intHealth.ToString();
        score.text = intScore.ToString();

	}

    public void pointInc (int x)
    {
        intScore += x;
    }

    public void healthDown(int x)
    {
        intHealth -= x;
    }

    public  int getHealth()
    {
        return intHealth;
    }

    public int getScore()
    {
        return intScore;
    }

	public void setHealth(int i)
	{
		intHealth = i;
	}
	public void setScore(int i)
	{
		intScore = i;
	}

}
