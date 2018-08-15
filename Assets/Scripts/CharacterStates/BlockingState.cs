using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingState : CharacterState {

	public BlockingState (Character newCharacter) : base (newCharacter){}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		//Debug.Log ("Ducking");
	}

	public override CharacterState HandleCommand (Command command)
	{
		if (command == Command.Null) {
			return new StandingState (character);
		}
		return null;
	}

	public override void EnterAction()
	{
		character.animations.SetBlockingBool (true);
	}

	public override void ExitAction()
	{
		character.animations.SetBlockingBool (false);
	}
}
