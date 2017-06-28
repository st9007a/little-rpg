using System.Collections.Generic;
using UnityEngine;
using MarkLight.Views.UI;

public class DialogBox : UIView {
	
	public string message = "";
	public bool active = false;

	private List<string> _messages;
	private int pointer = 0;

	public bool SetMessage (List<string> msg) {
		if (!active) {
			SetValue(() => active, true);
		}
		if (pointer < msg.Count) {
			SetValue(() => message, msg[pointer++]);
			return false;
		} else {
			SetValue(() => active, false);
			pointer = 0;
			return true;
		}
	}
}
