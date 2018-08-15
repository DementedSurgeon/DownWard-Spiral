using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : CharacterState {

	public AttackingState (Character newCharacter) : base (newCharacter){}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	public override void Update () {
		
	}

	public override CharacterState HandleCommand (Command command)
	{
		if (command == Command.Transition) {
			return new WindDownState (character);
		}
		return null;
	}

	public override void EnterAction()
	{
		//character.animations.SetAttackTrigger ();
		//character.offensiveHitboxManager.ActivateHitbox ();
	}

	public override void ExitAction ()
	{
		//character.offensiveHitboxManager.DeactivateHitbox ();
	}


}
