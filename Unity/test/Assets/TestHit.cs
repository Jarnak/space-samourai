﻿using UnityEngine;
using System.Collections;

public class TestHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		    {
			Debug.Log("hit");
			GameObject.FindGameObjectWithTag("Server").SendMessage("sendHit");
		}
	}
}
