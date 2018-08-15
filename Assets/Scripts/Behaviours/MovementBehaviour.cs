using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : HoldBehaviour {

	public float speed;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.transform.position += animator.transform.forward * Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		base.OnStateUpdate (animator, stateInfo, layerIndex);
	}
}
