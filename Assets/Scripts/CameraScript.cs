using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform lookAtObj;

	private float lastFrameX;

	void Start() {
		lastFrameX = transform.rotation.eulerAngles.x;
	}

	void Update() {

		/*if (Mathf.Abs(lastFrameX - transform.rotation.eulerAngles.x) > 0.0001f) {
			transform.LookAt(lookAtObj);
		}*/

		transform.LookAt(lookAtObj);
		//Debug.Log(lastFrameX - transform.rotation.eulerAngles.x);
		lastFrameX = transform.rotation.eulerAngles.x;


	}

}
