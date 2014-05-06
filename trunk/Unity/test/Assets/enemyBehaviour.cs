using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {


    public GameObject hud;
    

	// Use this for initialization
	void Start () 
    {	

        hud = GameObject.FindGameObjectWithTag("HUD");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "sabre")
        {
            hud.GetComponent<hudHandler>().pointInc(50);
			audio.Play();
			//Debug.Log("sound played");
			Destroy(this.gameObject);
            
        }
    }
}
