using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform lookAtObj;

	void Update() {
		transform.LookAt(lookAtObj);
	}

}
