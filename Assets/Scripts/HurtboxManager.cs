using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Health))]
public class HurtboxManager : MonoBehaviour {

	public EventHandler<OnReceivingHitEventArgs> OnImpact;

	private AttackLogic attackController = null;
	private Attack incomingAttack;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.transform.GetComponentInParent<AttackLogic> () != attackController) {
			attackController = col.transform.GetComponentInParent<AttackLogic> ();
		}
		StoreImpactInfo (attackController.GetCurrentAttack());
		if (OnImpact != null) {
			OnImpact (this, new OnReceivingHitEventArgs(attackController, gameObject));
		}
	}

	void StoreImpactInfo (Attack attack)
	{
		incomingAttack = attack;
	}

	public Attack GetIncomingAttack()
	{
		return incomingAttack;
	}

	/*public DefenseEquipment GetDefenseEquipment()
	{

	}*/

}

public class OnReceivingHitEventArgs : EventArgs {
	public AttackLogic attackLogic;
	public GameObject hurtbox;
	public OnReceivingHitEventArgs(AttackLogic targetAttackLogic, GameObject newhurtbox){
		attackLogic = targetAttackLogic;
		hurtbox = newhurtbox;
	}
}
