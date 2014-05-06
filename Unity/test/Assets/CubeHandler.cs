using UnityEngine;
using System.Collections;

public class CubeHandler : MonoBehaviour {
	public GameObject server;
	private DATA data;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		data = server.GetComponent<ServerHandler> ().getData ();
		rigidbody.AddForce( new Vector3 (data.getX (), data.getY (), data.getZ ()), ForceMode.Acceleration);
	}
}
