using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OffensiveHitboxManager : MonoBehaviour {

	[SerializeField]
	[NamedArrayAttribute(new string[]{"Left Hand", "Right Hand", "Left Foot", "Right Foot"})]
	private Hitbox[] hitboxes = new Hitbox[4];

	private BoxCollider impactedHitbox; 

	public EventHandler<OnHitEventArgs> OnHit;

	void Awake()
	{
		
	}
	// Use this for initialization
	void Start () {
		foreach (Hitbox hitbox in hitboxes) {
			hitbox.OnHit += Impact;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Impact(object sender, OnHitEventArgs e){
		OnHitEventArgs ev = new OnHitEventArgs (e.defenseLogic, e.hitbox);
		if (OnHit != null) {
			OnHit (this, ev);
		}
	}

	public void ActivateHitbox(int hitbox)
	{
		hitboxes [hitbox].hitbox.enabled = true;
	}

	public void DeactivateHitbox(int hitbox)
	{
		hitboxes [hitbox].hitbox.enabled = false;
	} 


}
