using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Transition 
{
	public Command command;
	public string parameterName;
	public string[] parameters;
	public bool commandContext;
	public AnimatorControllerParameter parameter;
	[HideInInspector]
	public AnimatorControllerParameterType type;
	public bool action;
}

