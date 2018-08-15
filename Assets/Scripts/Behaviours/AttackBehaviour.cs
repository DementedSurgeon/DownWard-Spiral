using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : PhaseBehaviour {

	public AttackLogic attackLogic;
	public Attack attack;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<OffensiveHitboxManager> ().OnHit += Blegh;
		base.OnStateEnter (animator, stateInfo, layerIndex);
		attack = attackLogic.GetCurrentAttack ();
		if (animator.GetComponent<Stamina> ().IsStaminaAvailable()) {
			Attack ();
		}
	}

	public override void FinishedWindingUp ()
	{
		base.FinishedWindingUp ();
		animator.GetComponent<OffensiveHitboxManager> ().ActivateHitbox ((int)attack.activeHitbox);
	}

	public override void StartedWindingDown ()
	{
		//animator.GetComponent<OffensiveHitboxManager> ().DeactivateHitbox ((int)attack.activeHitbox);
		if (attackLogic.GetComboNumber() < attackLogic.GetMaxCombo() && animator.GetComponent<Stamina> ().IsStaminaAvailable()) {
			base.StartedWindingDown ();
		}
	}

	public override void FinishedWindingDown ()
	{
		animator.GetComponent<OffensiveHitboxManager> ().DeactivateHitbox ((int)attack.activeHitbox);
		animator.GetComponent<OffensiveHitboxManager> ().OnHit -= Blegh;
		base.FinishedWindingDown ();
	}

	void Attack(){
		animator.GetComponent<Stamina> ().Expend (attack.stamingCost);
		animator.SetFloat ("AttackClass", attackLogic.GetCurrentClass());
		animator.SetFloat ("AttackNumber", (float)attackLogic.GetComboNumber() / 2);
		attackLogic.comboNumber++;
	}

	void Blegh(object sender, OnHitEventArgs e){
		if (attack.specialQuality != Specials.Piercing) {
			animator.GetComponent<OffensiveHitboxManager> ().DeactivateHitbox ((int)attack.activeHitbox);
		}
		Debug.Log (e.hitbox + "is" + e.hitbox.activeSelf);
	}
}
