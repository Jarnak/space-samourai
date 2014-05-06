using UnityEngine;
using System.Collections;

public class turnleft : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
	void OnTriggerEnter(Collider coll) 
    {
        //player.GetComponent<TileController>().lTurn();
	}
	
}
