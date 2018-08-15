using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private CharacterState charState;
	[HideInInspector]
	public InputHandler inputHandler;
	[HideInInspector]
	public Animations animations;
	[HideInInspector]
	public OffensiveHitboxManager offensiveHitboxManager;
	[HideInInspector]
	public HurtboxManager defensiveHitboxManager;
	[SerializeField]
	public Command activeCommand;
	[SerializeField]
	private Command newCommand;
	public CommandBuffer buffer;

	// Use this for initialization
	void Start () {
		animations = gameObject.GetComponent<Animations> ();
		offensiveHitboxManager = gameObject.GetComponent<OffensiveHitboxManager> ();
		defensiveHitboxManager = gameObject.GetComponent<HurtboxManager> ();
		inputHandler = gameObject.GetComponent<InputHandler> ();
		charState = new StandingState(this);
	}
	
	// Update is called once per frame
	void Update () {
		/*newCommand = inputHandler.InputToCommand ();
		if (activeCommand != newCommand) {
			activeCommand = newCommand;
			//HandleCommand (activeCommand);
		}*/
		//charState.Update ();
		//Debug.Log (charState);
		//Debug.Log (activeCommand);
	}

	public void HandleCommand(Command command)
	{
		CharacterState newState = charState.HandleCommand (activeCommand);
		if (newState != null) {
			charState.ExitAction ();
			charState = newState;
			charState.EnterAction ();
		}

	}
}
