using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Attack")]
[System.Serializable]
public struct Attack {

	public AttackType attackType;
	public int damage;
	public float stamingCost;
	public PossibleHitboxes activeHitbox;
	public Specials specialQuality;

}

public enum PossibleHitboxes {LeftHand, RightHand, LeftFoot, RightFoot};

public enum AttackType {Light = 0, Heavy = 100};

public enum AttackClass {Bouncer, Soldier, Mobster};

public enum AttackNumber {First = 0, Second = 50, Third = 100};

public enum Specials {None, Piercing, Knockback, Knockup};
