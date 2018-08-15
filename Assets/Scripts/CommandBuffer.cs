using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommandBuffer {

	public int size;
	public int commandLifespan;
	public Command[] lockedCommands;
	public bool locked = false;

	[SerializeField]
	public Queue<ComplexCommand> queue;

	public CommandBuffer(int newSize, int newCommandLifespan){
		size = newSize;
		commandLifespan = newCommandLifespan;
		queue = new Queue<ComplexCommand> (size);
	}

	public void Add(Command newCommand){
		if (locked) {
			for (int i = 0; i < lockedCommands.Length; i++) {
				if (newCommand == lockedCommands [i]) {
					if (queue.Count == size) {
						queue.Dequeue ();
					}
					queue.Enqueue (new ComplexCommand (newCommand, commandLifespan));
					i = lockedCommands.Length;
				}
			}
		} else {
			if (queue.Count == size) {
				queue.Dequeue ();
			}
			queue.Enqueue (new ComplexCommand (newCommand, commandLifespan));
		}
		/*
		if ((locked && newCommand == lockedCommand) || !locked) {
			if (queue.Count == size) {
				queue.Dequeue ();
			}
			queue.Enqueue (new ComplexCommand (newCommand, commandLifespan));
			//Debug.Log (newCommand);
		}*/
	}

	public Command Retrieve(){
		return queue.Dequeue ().command;
	}

	public void Expire(){
		if (queue.Count > 0) {
			if (queue.Peek ().timestamp <= Time.frameCount) {
					queue.Dequeue ();
				}
		}
	}

	public void Lock(Command[] acceptedCommands){
		lockedCommands = acceptedCommands;
		locked = true;
	}

	public void Unlock(){
		locked = false;
	}
}
