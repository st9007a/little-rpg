using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public List<EventScript> DEV_ACTION_LIST;
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
					DEV_ACTION_LIST[0].Handler();
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
