using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : CharacterState {

	public StandingState (Character newCharacter) : base (newCharacter){}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		//Debug.Log ("Standing");
	}

	public override CharacterState HandleCommand (Command command)
	{return null;/*
		if (command == Command.Block) {
			return new BlockingState (character);
		} else if (command == Command.MoveRight) {
			return new MovingRightState (character);
		} else if (command == Command.MoveLeft) {
			return new MovingLeftState (character);
		} else if (command == Command.AttackLight) {
			return new AttackWindUpState (character);
		} else if (command == Command.Dodge) {
			//return new DodgingState ();
		}
		return null;
		/*switch (command) {
		case Command.Attack:
			return new AttackingState (character, animations);
		case Command.Block:
			return new BlockingState (character, animations);
		case Command.MoveLeft:
			return new MovingLeftState (character, animations);
		case Command.MoveRight:
			return new MovingRightState (character, animations);
		case Command.Null:
			return null;
		default:
			return null;
		}*/
	}
}
