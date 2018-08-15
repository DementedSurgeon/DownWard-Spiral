using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBehaviour : StateTransitionBehaviour {

	bool checking = false;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		checking = true;
	}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (checking) {
			ExecuteTransition ();
		}
	}

	public override void ExecuteTransition ()
	{
		Command temp = inputHandler.RetrieveCommand ();
		foreach (Transition transition in transitions) {
			if ((transition.command == temp) == transition.commandContext) {
				if (transition.type == AnimatorControllerParameterType.Bool) {
					animator.SetBool (transition.parameterName, transition.action);
					if (!transition.action && !transition.commandContext) {
						inputHandler.AddCommand (temp);
					}
					checking = false;
				} else {
					animator.SetTrigger (transition.parameterName);
					checking = false;
				}
			}
		}
	}
}
