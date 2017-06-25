using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : StateMachineBehaviour {

	public const float jumpPoint = 0.2f;
	public const float fallPoint = 1.1f;
	public const float gravity = 9.8f;

	public bool isJump;
	public float jump;

	private float timer;
	private float originX;
	private float originZ;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		timer = 0;
		isJump = false;
	    animator.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, animator.gameObject.GetComponent<Rigidbody>().velocity.y, 0);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (timer < jumpPoint || timer > fallPoint) {
			animator.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		if (timer >= jumpPoint && !isJump) {
			isJump = true;
			animator.gameObject.GetComponent<Rigidbody>().velocity += Vector3.up * jump;
		}

		if (animator.gameObject.GetComponent<Rigidbody>().velocity.y > 0) {
			Vector3 newY = animator.gameObject.GetComponent<Rigidbody>().velocity;
			newY.y -= gravity * Time.deltaTime;
			animator.gameObject.GetComponent<Rigidbody>().velocity = newY;
		}
		timer += Time.deltaTime;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

}
