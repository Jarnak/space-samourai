using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {


    public hudHandler hud;
	private GameObject myBody;
    

	// Use this for initialization
	void Start () 
    {	
		hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<hudHandler>();
		myBody = transform.Find ("ninjajeu").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "sabre")
        {
            hud.pointInc(50);
			hud.stockEnergy(4);
			audio.Play();
			//Debug.Log("sound played");
			Destroy(this.gameObject);
            
        }
    }
	public void launch ()
	{

	}
}
