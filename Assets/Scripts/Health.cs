﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hurt(int damage)
	{
		health -= damage;
		gameObject.GetComponent<Animator> ().SetTrigger ("Flinch");
	}
}
