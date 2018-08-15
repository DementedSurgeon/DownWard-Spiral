using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState {

	public CharacterState (Character newCharacter)
	{
		character = newCharacter;
	}

	protected Character character;

	public virtual void Update () {
		
	}

	public virtual CharacterState HandleCommand(Command newCommand)
	{
		return null;
	}

	public virtual void EnterAction()
	{

	}

	public virtual void ExitAction()
	{

	}

}
