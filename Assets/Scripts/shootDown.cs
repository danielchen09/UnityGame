using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDown : StateMachineBehaviour {

	public GameObject arrow;
	public Rigidbody2D rb;
	public bool shot = false;
	public string owner;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		owner = (animator.gameObject.name.Equals ("Player")) ? "Player" : "Enemy";
		if (owner.Equals ("Player")) {
			GameObject.Find ("Player").GetComponent<Player> ().setVelocity (0);
		} else {
			animator.gameObject.GetComponent<Enemy> ().attacking (true);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.normalizedTime >= 0.6 && !shot) {
			if (owner.Equals("Player")) {
				animator.gameObject.GetComponent<Player> ().attack (0, -1.0f);
			} else {
				animator.gameObject.GetComponent<Enemy> ().attack ();
			}
			shot = true;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		shot = false;
		if (owner.Equals ("Player")) {
			GameObject.Find ("Player").GetComponent<Player> ().setVelocity (1);
			if (Input.GetKey (KeyCode.DownArrow)) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkDown");
			}
		} else {
			animator.gameObject.GetComponent<Enemy> ().attacking (false);
		}

	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
