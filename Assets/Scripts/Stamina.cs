using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {

	public float stamina;
	private float maxStamina;

	public float regenerationCooldown;
	private float regenerationTimer;

	// Use this for initialization
	void Start () {
		maxStamina = stamina;
	}
	
	// Update is called once per frame
	void Update () {
		if (regenerationTimer > 0) {
			regenerationTimer -= Time.deltaTime;
		}
		if (stamina < maxStamina) {
			if (regenerationTimer <= 0) {
				stamina += maxStamina * 0.05f * Time.deltaTime;
				if (stamina > maxStamina) {
					stamina = maxStamina;
				}
			}
		}
	}

	public void Expend(float cost){
		stamina -= cost;
		regenerationTimer = regenerationCooldown;
		if (stamina < 0) {
			stamina = 0;
		}
	}

	public bool IsStaminaAvailable(){
		if (stamina > 0) {
			return true;
		}
		return false;
	}
}
