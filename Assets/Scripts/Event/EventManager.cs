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
		SingleEvent message = store.getMessage(currentEventId, objectId);
		DialogBox db = GameObject.Find("DialogBox").GetComponent<DialogBox>();

		if (db.SetMessage(message)) {
			switch (message.callback) {
				case SingleEvent.CallbackAction.Door:
					Debug.Log("Open Door");
					break;
				default:
					break;
			}

			if (store.triggerEvent(currentEventId, objectId)) {
				currentEventId++;
			}
		}
	}

}
