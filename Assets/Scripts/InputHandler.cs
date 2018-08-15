using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	public delegate void MyDelegate();
	public MyDelegate OnNewCommand;
	protected Command command;

	public virtual void InputToCommand()
	{
		//return command = Command.Null;
	}

	public Command Movement(){
		return Command.Movement;
	}

	public Command AttackLight()
	{
		return Command.AttackLight;
	}

	public Command AttackHeavy()
	{
		return Command.AttackHeavy;
	}

	public Command Block()
	{
		return Command.Block;
	}

	public Command Flinch()
	{
		return Command.Flinch;
	}

	public Command Recoil()
	{
		return Command.Recoil;
	}

	public Command Dodge()
	{
		return Command.Dodge;
	}

	public virtual Command RetrieveCommand(){
		return Command.Null;
	}

	public virtual void AddCommand(Command newCommand){

	}

	public virtual void LockBuffer(Command[] acceptedCommands){

	}

	public virtual void UnlockBuffer(){

	}
}
