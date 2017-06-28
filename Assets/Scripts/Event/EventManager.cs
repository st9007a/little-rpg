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
		List<string> message = store.getMessage(currentEventId, objectId);
		DialogBox db = GameObject.Find("DialogBox").GetComponent<DialogBox>();

		if (db.SetMessage(message) && store.triggerEvent(currentEventId, objectId)) {
			currentEventId++;
		}
	}

}
