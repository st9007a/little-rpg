using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public int currentEventId{ private set; get; }
	private EventStore store;

	void Awake() {
		store = EventStore.getDefault();
		currentEventId = 0;
	}

	public void postMessage(int objectId) {
		string message = store.getMessage(currentEventId, objectId);

		if (store.triggerEvent(currentEventId, objectId)) {
			currentEventId++;
		}

		Debug.Log(message);
	}

}
