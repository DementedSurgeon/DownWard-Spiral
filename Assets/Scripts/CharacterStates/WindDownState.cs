using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDownState : CharacterState {

	public WindDownState (Character newCharacter) : base (newCharacter){}

	public override CharacterState HandleCommand (Command newCommand)
	{
		if (newCommand == Command.Transition) {
			return new StandingState (character);
		} else if (newCommand == Command.AttackLight) {
			return new AttackWindUpState (character);
		}
		return null;
	}
}
