using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class AnimatorController : MonoBehaviour {

	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("velocity", this.GetComponent<Rigidbody>().velocity.magnitude);	
	}
}
