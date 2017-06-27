using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScript : MonoBehaviour {
	public virtual void Handler() {
		Debug.Log("Virtual");
	}
}
