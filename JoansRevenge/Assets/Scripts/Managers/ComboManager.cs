using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour {
	Attack[] comboAttacks = new Attack[3];
	public Transform[] slots = new Transform[3];
	public AnimationCurve addingCurve;
	[Range(10, 15f)] public float addingSpeed;
	int actionCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator PlayCombo()
	{
		yield return null;
	}

	public void CheckAttacks()
	{
		
	}

	public IEnumerator AddToCombo(ActionContainer aC)
	{
		if (actionCount >= 3)
			yield break;
		actionCount += 1;

		InputManager.dragging = false;
		aC.gameObject.layer = 0;
		Transform actionTransform = aC.transform;

		Vector3 assignedPosition = slots [actionCount-1].position;
		Vector3 originPosition = actionTransform.position;
		float dist = Vector3.Distance (originPosition, assignedPosition);

		for (float i = 0; i <= 1f; i += addingSpeed / dist * Time.deltaTime) 
		{
			actionTransform.position = Vector3.Lerp (originPosition, assignedPosition, addingCurve.Evaluate(i));
			yield return null;
		}
		actionTransform.position = assignedPosition;

		//Add attack to the combo
		comboAttacks [actionCount-1] = aC.attack;

		yield return null;
	}
}
