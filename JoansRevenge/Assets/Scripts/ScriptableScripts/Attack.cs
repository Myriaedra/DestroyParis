using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject {
	public float damage;
	public GameManager.AttackType type;
	public Attack[,] possibleFusions;

	// Use this for initialization
	public abstract void AttackEffect () ;

}
