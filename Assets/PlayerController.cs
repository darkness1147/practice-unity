using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private Animator anim;
	private Rigidbody rb;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private bool isGrounded;
	[SerializeField] private Vector3 camForward;
	[SerializeField] private Vector3 camRight;
	[SerializeField] private Vector3 camCross;
	[SerializeField] private Vector3 translationTarget;
	[SerializeField] float xMultiplier = 0;
	[SerializeField] float zMultiplier = 0;
	void Start()
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
//		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150f;
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 5f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 5f;
		if (mainCamera != null) 
		{
			//use rig direction
			camForward = mainCamera.transform.parent.forward;
			camForward.y = 0;
			camRight = mainCamera.transform.parent.right;
			camRight.y = 0;


			if ( Input.GetAxis ("Horizontal") < 0 && Input.GetButton ("Horizontal")) 
			{
				xMultiplier = -1;
			}
			if ( Input.GetAxis ("Horizontal") > 0 && Input.GetButton ("Horizontal")) 
			{
				xMultiplier = 1;
			}
			if ( Input.GetButtonUp ("Horizontal")) 
			{
				xMultiplier = 0;
			}
			if (Input.GetAxis ("Vertical") < 0 && Input.GetButton ("Vertical")) 
			{
				zMultiplier = -1;
			}
			if (Input.GetAxis ("Vertical") > 0 && Input.GetButton ("Vertical")) 
			{
				zMultiplier = 1;
			}
			if (Input.GetButtonUp ("Vertical")) 
			{
				zMultiplier = 0;
			}
			camCross = new Vector3((camForward.x * zMultiplier + camRight.x * xMultiplier) /2, 0, (camForward.z * zMultiplier + camRight.z * xMultiplier) /2) + transform.position;
			Debug.DrawLine (transform.position, camCross,Color.red);

//			if (camForward != Vector3.zero || camRight != Vector3.zero)
//			{
//			transform.LookAt(camCross);
			Quaternion targetRot = Quaternion.LookRotation(camCross - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 10 * Mathf.Max(Mathf.Abs(xMultiplier),Mathf.Abs(zMultiplier)));
				transform.rotation = Quaternion.Euler(new Vector3(0,transform.eulerAngles.y, 0));
			transform.Translate (0, 0, Mathf.Max(Mathf.Abs(xMultiplier/20f),Mathf.Abs(zMultiplier/20f)));
//			}
		}
		else 
		{
			transform.Translate (0, 0, z);
			transform.Rotate (0, x, 0);
		}

		if (anim != null) 
		{
			if (zMultiplier > 0f || xMultiplier != 0f) {
				anim.SetBool ("Walk", true);
			}
			if (zMultiplier == 0f && xMultiplier == 0f) {
				anim.SetBool ("Walk", false);
				anim.SetBool ("WalkReverse", false);
			}
			if (zMultiplier < 0f ) {
//				anim.SetBool ("WalkReverse", true);
				anim.SetBool ("Walk", true);
			}
		}

		if (Input.GetButtonDown ("Jump")) {
			if (rb != null) {
				rb.AddForce (Vector3.up * 3f, ForceMode.Impulse);
			}
		} 

		if (Input.GetButton ("Jump")) 
		{
			if (anim != null) {
				anim.SetBool ("Jump", true);
			}
		}
		else
		{
			if (anim != null) {
				anim.SetBool ("Jump", false);
			}
		}
	}
}
