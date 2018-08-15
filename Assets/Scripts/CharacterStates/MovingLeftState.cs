using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftState : CharacterState {

	public MovingLeftState (Character newCharacter) : base (newCharacter){}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		character.transform.position -= Vector3.left * 10 * Time.deltaTime;

	}

	public override CharacterState HandleCommand (Command command)
	{
		if  (Input.GetKeyUp (KeyCode.LeftArrow)){
			return new StandingState (character);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow))	{
			return new MovingRightState (character);
		}
		return null;
	}

	public override void EnterAction ()
	{
		character.animations.SetMoveLeftBool (true);
	}

	public override void ExitAction ()
	{
		character.animations.SetMoveLeftBool (false);
	}
}
