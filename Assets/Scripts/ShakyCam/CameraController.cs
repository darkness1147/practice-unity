using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform Target;
	public float DistanceFromTarget = 5f;
	public float HeightFromTarget = 2f;
	public bool LookAtTarget;
	public bool FollowTarget;
	public bool UseDynamicHeight;
	[Header("Shake Effect")]
	public float stressLevel;
	public float amplitudeLevel;

	private Camera cameraObject;
	[SerializeField]
	private Collider cameraCollider;
	void Awake()
	{
		cameraObject = GetComponentInChildren<Camera> ();
		cameraCollider = cameraObject.GetComponent<Collider> ();
	}

	private RaycastHit hit;

	void Update () 
	{
		if (FollowTarget) {
			if (Target != null) 
			{
				Vector3 objectPosition = Target.position;
				objectPosition.y = HeightFromTarget;
				objectPosition.z = Target.position.z - DistanceFromTarget;
				//cameraObject.transform.localPosition = new Vector3 (cameraObject.transform.localPosition.x, HeightFromTarget, -DistanceFromTarget);
				if (LookAtTarget) {
					cameraObject.transform.LookAt (Target);
				}
				transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * 8f);
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha1)){
			AddCameraShock ();
		}
		if (stressLevel < 0) {
			stressLevel = 0;
		}

		if (stressLevel > 0) 
		{
			stressLevel -= Mathf.Pow(Time.deltaTime * 5,1.9f);
		}

		if (amplitudeLevel < 0) {
			amplitudeLevel = 0;
		}
		if (amplitudeLevel > 0) 
		{
			amplitudeLevel -= Mathf.Pow(Time.deltaTime * 5,1.75f);
			Vector3 shakeVector = Vector3.zero;
			if (LookAtTarget) {
				shakeVector = new Vector3 (
					cameraObject.transform.localEulerAngles.x + Random.Range (-2f, 2f) * amplitudeLevel * stressLevel, 
					cameraObject.transform.localEulerAngles.y + Random.Range (-5f, 5f) * amplitudeLevel * stressLevel,
					cameraObject.transform.localEulerAngles.z + Random.Range (-5f, 5f) * amplitudeLevel * stressLevel);
			} else {
				shakeVector = new Vector3 (Random.Range (-2f, 2f) * amplitudeLevel * stressLevel, Random.Range (-5f, 5f) * amplitudeLevel * stressLevel, Random.Range (-5f, 5f) * amplitudeLevel * stressLevel);
			}
			cameraObject.transform.localEulerAngles = shakeVector;
		}
//		if (amplitudeLevel == 0) {
//			cameraObject.transform.localEulerAngles = Vector3.zero;
//		}

		if (stressLevel > 1) {
			stressLevel = 1;
		}
		if (amplitudeLevel > 1) {
			amplitudeLevel = 1;
		}
	}

	public void AddCameraShock (float value){
		amplitudeLevel += value;
		stressLevel += value;
	}

	public void AddCameraShock(){
		AddCameraShock (0.25f);
	}
}
