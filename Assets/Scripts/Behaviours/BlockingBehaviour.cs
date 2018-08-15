using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingBehaviour : HoldBehaviour {

	//Ugly workaround, need multi-clause transition conditions in order to make it work

	/*
	public override void ExecuteTransition ()
	{
		Command temp = inputHandler.RetrieveCommand ();
		if (temp == Command.Null || (temp != Command.Null && temp != Command.Block)) {
			foreach (Transition transition in transitions) {
				if ((transition.command == temp) == transition.commandContext) {
					if (transition.type == AnimatorControllerParameterType.Bool) {
						animator.SetBool (transition.parameterName, transition.action);
					} else {
						animator.SetTrigger (transition.parameterName);
					}
				}
			}
		}
	}*/
}
