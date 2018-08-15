using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StateTransitionBehaviour : StateMachineBehaviour {

	public InputHandler inputHandler;
	public Transition[] transitions;
	public Animator animator;
	public Animations animations;

	public void SetAnimator (Animator newAnimator)
	{
		animator = newAnimator;
		if (inputHandler == null) {
			inputHandler = animator.GetComponent<InputHandler> ();
		}
	}

	public void PopulateTransitionArray()
	{
		for (int c = 0; c < transitions.Length; c++) {
			for (int i = 0; i < animator.parameters.Length; i++) {
				if (transitions[c].parameterName == animator.parameters [i].name) {
					transitions[c].parameter = animator.parameters [i];
					transitions [c].type = transitions [c].parameter.type;
				}
			}
		}
	}

	public virtual void ExecuteTransition()
	{
		Command temp = inputHandler.RetrieveCommand ();
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


}
