using UnityEngine;
using System.Collections;

public class turnright : MonoBehaviour 
{
	public GameObject player;
	// Use this for initialization
	void Start () 
    {
	}

    void Update()
    {
    }
	// Update is called once per frame
	void OnTriggerEnter(Collider coll)
    {
        //player.GetComponent<TileController>().rTurn();
	}
}
