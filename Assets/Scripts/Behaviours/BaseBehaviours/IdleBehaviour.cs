using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateTransitionBehaviour {


	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		inputHandler.OnNewCommand += ExecuteTransition;
	}

	public override void ExecuteTransition ()
	{
		Command temp = inputHandler.RetrieveCommand ();
		foreach (Transition transition in transitions) {
			if ((transition.command == temp) == transition.commandContext) {
				if (transition.type == AnimatorControllerParameterType.Bool) {
					animator.SetBool (transition.parameterName, transition.action);
					inputHandler.OnNewCommand -= ExecuteTransition;
				} else {
					animator.SetTrigger (transition.parameterName);
					inputHandler.OnNewCommand -= ExecuteTransition;
				}
			}
		}
	}
}
