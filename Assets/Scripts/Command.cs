using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Command{Null, AttackLight, AttackHeavy, Block, Dodge, Flinch, Recoil, Transition, Movement};

[System.Serializable]
public class ComplexCommand {
	public Command command;
	public int timestamp;
	public int lifespan;

	public ComplexCommand(Command newCommand, int newLifespan) {
		command = newCommand;
		lifespan = newLifespan;
		timestamp = Time.frameCount + lifespan;
	}
}

