using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : EventScript {
    private const int OPEN_STATE = 0;
	private const int CLOSE_STATE = 1;

	public int state{ private set; get; }

	void Awake() {
		state = CLOSE_STATE;
	}

	void ToggleDoor() {
		if (state == CLOSE_STATE) {
			GetComponent<Animator>().SetTrigger("open");
			state = OPEN_STATE;
		}
		else {
			GetComponent<Animator>().SetTrigger("close");
			state = CLOSE_STATE;
		}
	}

	public override void Handler() {
		ToggleDoor();
	}
}
