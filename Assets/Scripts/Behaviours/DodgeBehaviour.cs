using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBehaviour : PhaseBehaviour {

	public bool dodging = false;
	public float direction;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter (animator, stateInfo, layerIndex);
		if (Input.GetAxis ("Horizontal") > 0) {
			direction = 1;
		} else {
			direction = 0;
		}
		animator.SetFloat ("DodgeDirection", direction);
	}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate (animator, stateInfo, layerIndex);
		if (dodging) {
			if (direction == 0) {
				animator.transform.position += Vector3.right * -1 * Time.deltaTime * stateInfo.speed;
			} else {
				animator.transform.position += Vector3.right * Time.deltaTime * stateInfo.speed;
			}
		}
	}

	public override void FinishedWindingUp ()
	{
		base.FinishedWindingUp ();
		dodging = !dodging;
	}

	public override void FinishedWindingDown ()
	{
		base.FinishedWindingDown ();
		dodging = !dodging;
	}

}
