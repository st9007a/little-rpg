using System.Collections;
using System.Collections.Generic;

public class SingleEvent: List<string> {

	public enum CallbackAction {
		None,
		Door,
	}
	public CallbackAction callback;

	public SingleEvent(CallbackAction cb = CallbackAction.None) {
		callback = cb;
	}

}
