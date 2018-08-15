using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftBehaviour : HoldBehaviour {

	public float speed;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.transform.position -= Vector3.right * Time.deltaTime * speed;
	}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate (animator, stateInfo, layerIndex);
		animator.transform.position -= Vector3.right * Time.deltaTime * speed;
	}
}
