using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : StateMachineBehaviour {


	private Transform Player;
	[SerializeField] LayerMask wahtisground;


	[SerializeField] private float Speed;
   

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		//check = GameObject.FindGameObjectWithTag ("Check").transform;

	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {


//		RaycastHit2D ray = Physics2D.Raycast (check.position,Vector2.down,5f);
//		Debug.DrawRay (check.position, Vector2.down * 5f, Color.blue);
//
//		if (ray.collider !=null) {
			animator.transform.position = Vector2.MoveTowards (animator.transform.position, Player.position, Speed * Time.deltaTime);
		//}
	
        
    
    
    
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

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
