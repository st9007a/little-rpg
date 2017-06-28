using UnityEngine;
using MarkLight.Views.UI;

public class DialogBox : UIView {
	
	public string message = "";
	public bool active = false;
	public void OnClick() {
		Debug.Log("test");
	}
}
