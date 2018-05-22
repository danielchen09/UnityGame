using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeUp : StateMachineBehaviour {

	private GameObject hitBox;
	private bool hit = false;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.normalizedTime >= 0.5 && !hit) {
			hitBox = Instantiate (Resources.Load<GameObject> ("meleeHitbox"), animator.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
			hitBox.GetComponent<meleeHitBox> ().setOwner (animator.gameObject);
			hit = true;
			if (Input.GetKey (KeyCode.UpArrow) && animator.gameObject.name.IndexOf("Player") != -1) {
				animator.ResetTrigger ("idle");
				animator.SetTrigger ("walkUp");
			}
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (hitBox != null) {
			Destroy (hitBox);
		}
		hit = false;
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
