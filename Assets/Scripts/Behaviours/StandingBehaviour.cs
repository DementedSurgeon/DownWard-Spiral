using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingBehaviour : IdleBehaviour {

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<AttackLogic> ().comboNumber = 0;
		base.OnStateEnter(animator, stateInfo, layerIndex);
	}

	public override void ExecuteTransition ()
	{
		base.ExecuteTransition ();
	}
	/*
	public override void ExecuteTransition()
	{
		Command temp = inputHandler.RetrieveCommand ();
		if (((temp == Command.AttackLight || temp == Command.Block || temp == Command.Dodge) && animator.GetComponent<Stamina> ().IsStaminaAvailable ()) || (temp != Command.AttackLight && temp != Command.Block && temp != Command.Dodge)) {
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
	}*/
}
	
