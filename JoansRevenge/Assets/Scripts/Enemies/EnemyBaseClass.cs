using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour {
	public Stats enemyStats;

	public virtual void QTE_Effect()
	{
		
	}

	public virtual void TakeDamage(int damage, GameManager.AttackType type)
	{
		
	}
}
