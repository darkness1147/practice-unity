using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSensors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.white);
		Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0,0.25f,1)) * 100, Color.white);
		Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0,0.25f,1)) * 100, Color.white);
		Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f,0,1)) * 100, Color.white);
		Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f,0,1)) * 100, Color.white);

		/*
		 * what i need: min distance of how target is considered "sighted" and "barely sighted"
		 * 
		*/
	}

	void DummyMethod(){

	}
}
