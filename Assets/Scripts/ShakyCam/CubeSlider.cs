using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSlider : MonoBehaviour {

	// Use this for initialization
	Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			rb.AddForce (Vector3.up * 200,ForceMode.Force);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			rb.AddForce (Vector3.right * 20,ForceMode.Force);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			rb.AddForce (Vector3.right * -20,ForceMode.Force);
		}
	}
}
