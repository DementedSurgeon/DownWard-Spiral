using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic : MonoBehaviour {

	//2D Array with all attacks for all classes, access it with cast enum, looks neat and works decently

	public int comboNumber;
	public int maxCombo;

	public AttackClass attackClass;

	public Attack[] lightAttacks;
	public Attack[] heavyAttacks;

	public Attack currentAttack;
	private OffensiveHitboxManager hitboxManager;

	// Use this for initialization
	void Start () {
		hitboxManager = gameObject.GetComponent<OffensiveHitboxManager> ();
		hitboxManager.OnHit += AnalyseHit;
		maxCombo = lightAttacks.Length; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Attack GetCurrentAttack()
	{
		return lightAttacks [comboNumber];
	}

	public int GetComboNumber(){
		return comboNumber;
	}

	public int GetMaxCombo(){
		return maxCombo;
	}

	public float GetCurrentClass(){
		float temp = (int)attackClass;
		temp = temp / 2;
		return temp;
	}

	public void AnalyseHit(object sender, OnHitEventArgs hitData){
		DefenseLogic logic = hitData.defenseLogic;
		if (logic.activeStatus != DefenseLogic.Status.Idle) {
			if (logic.activeStatus == DefenseLogic.Status.Parrying) {
				gameObject.GetComponent<Animator> ().SetTrigger ("Bounce");
			}
		}
	}
}
