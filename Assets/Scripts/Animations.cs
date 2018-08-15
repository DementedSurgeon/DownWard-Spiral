using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Animations : MonoBehaviour {

	private Animator animator;
	private StateTransitionBehaviour[] behaviours;
	private int attackTriggerHash;
	private int moveRightBoolHash;
	private int moveLeftBoolHash;
	private int flinchTriggerHash;
	private int blockBoolHash;

	// Use this for initialization
	void Awake()
	{
		animator = gameObject.GetComponent<Animator> ();
	}

	void Start () {
		behaviours = animator.GetBehaviours<StateTransitionBehaviour> ();
		foreach (StateTransitionBehaviour transitionBehaviour in behaviours) {
			transitionBehaviour.SetAnimator (animator);
			transitionBehaviour.animations = this;
			transitionBehaviour.PopulateTransitionArray ();
		}
		foreach (AttackBehaviour attackBehaviour in behaviours.OfType<AttackBehaviour>()) {
			attackBehaviour.attackLogic = gameObject.GetComponent<AttackLogic> ();
		}
		InputBlock[] inputLockers = animator.GetBehaviours<InputBlock> ();
		foreach (InputBlock inputLock in inputLockers) {
			inputLock.inputHandler = gameObject.GetComponent<InputHandler> ();
		}
		attackTriggerHash = Animator.StringToHash ("Attack");
		moveRightBoolHash = Animator.StringToHash ("MovingRight");
		moveLeftBoolHash = Animator.StringToHash ("MovingLeft");
		flinchTriggerHash = Animator.StringToHash ("Flinch");
		blockBoolHash = Animator.StringToHash ("Blocking");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAttackTrigger()
	{
		animator.SetTrigger (attackTriggerHash);
	}

	public void SetMoveRightBool(bool newBool)
	{
		animator.SetBool (moveRightBoolHash, newBool);
	}

	public void SetMoveLeftBool(bool newBool)
	{
		animator.SetBool (moveLeftBoolHash, newBool);
	}

	public void SetFlinchTrigger()
	{
		animator.SetTrigger (flinchTriggerHash);
	}

	public void SetBlockingBool(bool newBool)
	{
		animator.SetBool (blockBoolHash, newBool);
	}
}
