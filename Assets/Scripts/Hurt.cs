using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour {

	Health health;

	// Use this for initialization
	void Start () {
		health = gameObject.GetComponent<Health> ();
		StartCoroutine (Hurting ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Hurting(){
		while (true) {
			yield return new WaitForSeconds(3);
			health.Hurt (1);
		}
	}
}
