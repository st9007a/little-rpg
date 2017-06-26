using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public EventTrigger trigger;

	void Start () {
		trigger.Handler += OpenDoor;
	}

	void OpenDoor() {
		GetComponent<Animator>().SetTrigger("open");
		trigger.Handler -= OpenDoor;
		trigger.Handler += CloseDoor;
	}

	void CloseDoor() {
		GetComponent<Animator>().SetTrigger("close");
		trigger.Handler -= CloseDoor;
		trigger.Handler += OpenDoor;
	}
}
