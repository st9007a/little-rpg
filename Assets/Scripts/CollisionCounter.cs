using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCounter : MonoBehaviour {

	public int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}

	void OnTriggerEnter (Collider other) {
		counter++;
	}

	void OnTriggerExit (Collider other) {
		counter--;
	}
	
}
