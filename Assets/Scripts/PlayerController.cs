using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputHandler {

	public int commandFrameLifespan;
	[SerializeField]
	CommandBuffer buffer = new CommandBuffer(3, 30);

	public void Awake(){
		CommandBuffer buffer = new CommandBuffer (3, commandFrameLifespan);
	}

	public void Start(){
		
	}

	public void Update(){
		buffer.Expire ();
		InputToCommand ();
	}

	public override void InputToCommand ()
	{
		if (Input.GetKeyDown (KeyCode.X)) {
				gameObject.GetComponent<Animator> ().SetTrigger ("Flinch");
			}

		if (Input.GetKeyDown (KeyCode.A)) {
			AddCommand(AttackLight ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		} 

		if (Input.GetKeyDown (KeyCode.D)) {
			AddCommand(AttackHeavy ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		} 

		if (Input.GetKey (KeyCode.S)) {
			AddCommand(Block ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		} 

		if (Input.GetKeyDown (KeyCode.Space)) {
			AddCommand(Dodge ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
			AddCommand (Movement ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		}

		/*
		if (Input.GetKey (KeyCode.LeftArrow)) {
			AddCommand(MoveLeft ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			AddCommand(MoveRight ());
			if (OnNewCommand != null) {
				OnNewCommand ();
			}
		}*/
				
	}

	public override Command RetrieveCommand ()
	{
		if (buffer.queue.Count > 0) {
			//Debug.Log ("Woo!");
			return buffer.Retrieve ();

		}
		//Debug.Log ("Aw!");
		return base.RetrieveCommand ();
	}

	public override void AddCommand (Command newCommand)
	{
		buffer.Add (newCommand);
	}

	public override void LockBuffer (Command[] acceptedCommands)
	{
		buffer.queue.Clear ();
		buffer.Lock (acceptedCommands);
	}

	public override void UnlockBuffer ()
	{
		buffer.Unlock ();
	}

}
