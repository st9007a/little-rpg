using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraScript : MonoBehaviour {

	public GameObject player;

	void Update () {
		transform.position = new Vector3(player.transform.position.x, 10, player.transform.position.z);		
	}
}
