using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {


	public delegate void HandleAction();
	public event HandleAction Handler;

	private bool isActive = false;
	
	void Update () {
		if (Input.GetKeyDown("z") && isActive && Handler != null) {
			Handler();
		}
	}

	void OnTriggerEnter(Collider c) {
		isActive = true;
	}

	void OnTriggerExit(Collider c) {
		isActive = false;
	}
}
