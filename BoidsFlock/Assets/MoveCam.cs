using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour {
	float cammovespeedud = 1.0f;
	float cammovespeeds = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float upandDwn = Input.GetAxis ("Vertical") * cammovespeedud;
		float side = Input.GetAxis ("Horizontal") * cammovespeeds;

		transform.Translate (side, upandDwn, 0);
	}
}
