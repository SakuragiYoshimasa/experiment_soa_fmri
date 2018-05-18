using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	 	float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		Debug.LogFormat("x:{0}, y:{1}", x, y);

	}
}
