using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseLogic : MonoBehaviour {

	private HurtboxManager defensiveHitboxManager;
	private Health health;
	public Block currentBlock;
	public Parry currentParry;
	public Push currentPush;
	public enum Status {Blocking, Parrying, Pushing, Idle};
	public Status activeStatus = Status.Idle;


	void Awake()
	{
		
	}
	// Use this for initialization
	void Start () {
		defensiveHitboxManager = gameObject.GetComponent<HurtboxManager> ();
		defensiveHitboxManager.OnImpact += ImpactAnalysis;
		health = gameObject.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ImpactAnalysis(object sender, OnReceivingHitEventArgs e)
	{
		Attack incomingAttack = e.attackLogic.lightAttacks [e.attackLogic.comboNumber];
		AttackLogic logic = e.attackLogic;
		if (activeStatus != Status.Idle) {
			if (activeStatus == Status.Blocking) {
				health.Hurt (incomingAttack.damage / 2);
				if (incomingAttack.specialQuality == Specials.Knockback) {

				}
			}
			} else {
			health.Hurt (incomingAttack.damage);
		}
	}

	public int GetBlockDefense()
	{
		return currentBlock.defense;
	}

	public float GetParryStun()
	{
		return currentParry.stun;
	}

	public float GetPushKnockback()
	{
		return currentPush.knockback;
	}
}
