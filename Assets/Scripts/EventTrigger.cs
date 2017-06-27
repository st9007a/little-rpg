using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

	public int objectId;
	public bool autoTrigger = false;

	public delegate void HandleAction();
	public event HandleAction Handler;

	private bool isActive = false;
	private EventManager em;

	void Awake () {
		em = GameObject.Find("EVENTMANAGER").GetComponent<EventManager>();
	}
	
	void Update () {
		if (Input.GetKeyDown("z") && isActive || autoTrigger) {
			//Handler();
			em.postMessage(objectId);
		}
	}

	void OnTriggerEnter(Collider c) {
		isActive = true;
	}

	void OnTriggerExit(Collider c) {
		isActive = false;
	}
}
