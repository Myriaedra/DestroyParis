using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEnemy : EnemyBaseClass {

	public override void QTE_Effect ()
	{
		//What happends when it's touched
	}
	
	public override void TakeDamage (int damage, GameManager.AttackType type)
	{
		//What happend when it takes damages
	}
}
