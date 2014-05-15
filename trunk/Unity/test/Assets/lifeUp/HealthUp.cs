using UnityEngine;
using System.Collections;

public class HealthUp : MonoBehaviour {
	
	private bool withAndroid = false;
	public GameObject hud;
	Vector3 rotation = new Vector3(0,10,0);
	
	
	
	void Start () {
		
		hud = GameObject.FindGameObjectWithTag("HUD");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotation);
	}
	void OnTriggerEnter(Collider coll)
	{
		/* if (coll.transform.tag == "sabre" )
		{

			Debug.Log(coll); 
			Debug.Log ( coll.gameObject.ToString()); 
			Debug.Log ( coll.gameObject.name );
			coll.gameObject.SendMessage("healed");

			Destroy(this.gameObject);
		}
		*/
		
		if (coll.transform.tag == "Player")
		{
			
			//Debug.Log(coll); 
			//Debug.Log ( coll.gameObject.ToString()); 
			//Debug.Log ( coll.gameObject.name );
			coll.gameObject.SendMessage("healed");
			
			Destroy(this.gameObject);
		}
		
	}
}