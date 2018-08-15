using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRightState : CharacterState {

	public MovingRightState (Character newCharacter) : base (newCharacter){}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		character.transform.position -= Vector3.right * 10 * Time.deltaTime;
		Debug.Log ("Moving Right");
	}

	public override CharacterState HandleCommand (Command command)
	{
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			return new StandingState (character);
		} else if (Input.GetKeyUp (KeyCode.RightArrow) && Input.GetKey (KeyCode.LeftArrow))	{
			return new MovingLeftState (character);
		}
		return null;
	}

	public override void EnterAction ()
	{
		character.animations.SetMoveRightBool (true);
	}

	public override void ExitAction ()
	{
		character.animations.SetMoveRightBool (false);
	}
}
