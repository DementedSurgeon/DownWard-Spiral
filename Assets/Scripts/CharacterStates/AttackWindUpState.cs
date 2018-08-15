using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWindUpState : CharacterState {

	public AttackWindUpState (Character newCharacter) : base (newCharacter){}

	public override void EnterAction ()
	{
		character.animations.SetAttackTrigger ();
	}

	public override CharacterState HandleCommand (Command command)
	{
		if (command == Command.Transition) {
			return new AttackingState(character);
		}
		return null;
	}
}
