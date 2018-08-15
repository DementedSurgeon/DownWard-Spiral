using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseBehaviour : StateTransitionBehaviour {

	[Range(0,50)]
	public int windUpTimePercentage;
	[Range(50,100)]
	public int windDownTimePercentage;

	public float windUp;
	public float windDown;

	public bool windingUp;
	public bool windingDown;

	private float timer;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		windUp = stateInfo.length * windUpTimePercentage / 100;
		windDown = stateInfo.length * windDownTimePercentage / 100;
		timer = 0;
		StartedWindingUp ();
	}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timer += Time.deltaTime;
		if (windingUp) {
			if (timer > windUp && windingUp == true) {
				FinishedWindingUp ();
			}
		} else {
			if (timer > windDown && windingDown == false) {
				StartedWindingDown ();
			}
		}
	}

	public override void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		FinishedWindingDown ();
	}

	public virtual void StartedWindingUp(){
		windingUp = true;
	}

	public virtual void FinishedWindingUp(){
		windingUp = false;
	}

	public virtual void StartedWindingDown(){
		windingDown = true;
		ExecuteTransition ();
	}

	public virtual void FinishedWindingDown(){
		windingDown = false;
	}
}
