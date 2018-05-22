using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject enemy;
		enemy = Instantiate (Resources.Load<GameObject> ("Murdue1"), new Vector3 (animator.gameObject.transform.position.x, animator.gameObject.transform.position.y, 0), Quaternion.identity);
		enemy.gameObject.name = "Enemy";
		enemy = Instantiate (Resources.Load<GameObject> ("Murdue2"), new Vector3 (animator.gameObject.transform.position.x, animator.gameObject.transform.position.y, 0), Quaternion.identity);
		enemy.gameObject.name = "Enemy";
		Destroy (animator.gameObject);	
		GameObject.Find ("Player").GetComponent<Player> ().setScore (GameObject.Find ("Player").GetComponent<Player> ().getScore () + 1);
		GameObject.Find ("Player").GetComponent<Player> ().incrementEnergy (20);
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
