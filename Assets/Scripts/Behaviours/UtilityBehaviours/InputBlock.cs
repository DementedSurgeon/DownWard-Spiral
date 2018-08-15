using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : StateMachineBehaviour {

	public Command[] priorityCommands;
	public InputHandler inputHandler;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		inputHandler.LockBuffer (priorityCommands);
	}

	public override void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		inputHandler.UnlockBuffer();
	}
}
