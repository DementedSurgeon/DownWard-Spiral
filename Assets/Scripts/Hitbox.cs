using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hitbox : MonoBehaviour {

	public Collider hitbox;
	public EventHandler<OnHitEventArgs> OnHit;

	void Start(){
		hitbox = gameObject.GetComponent<Collider> ();
	}

	void OnTriggerEnter(Collider col){
		OnHitEventArgs e = new OnHitEventArgs (col.GetComponent<DefenseLogic> (), gameObject);
		if (OnHit != null){
			OnHit(this, e);
		}
	}
}

public class OnHitEventArgs : EventArgs {
	public DefenseLogic defenseLogic;
	public GameObject hitbox;
	public OnHitEventArgs(DefenseLogic targetDefenseLogic, GameObject newHitbox){
		defenseLogic = targetDefenseLogic;
		hitbox = newHitbox;
	}
}
