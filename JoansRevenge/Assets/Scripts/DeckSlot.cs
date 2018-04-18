using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSlot : MonoBehaviour {
	public float speed;
	ActionContainer linkedAction;

	void Start()
	{
		linkedAction = GetComponentInChildren<ActionContainer> ();
		linkedAction.parentSlot = transform;
	}

	void Update () 
	{
		//Slide down
		transform.localPosition = new Vector3 (0, transform.localPosition.y + speed * Time.deltaTime, 0);

		//Destroy when out of screen
		if (transform.position.y > 7f) 
		{
			//If the slot is not empty, put the action back in the deck
			if (linkedAction.transform.parent != null) {
				linkedAction.AddSelfToDeck ();
			}

			Destroy (gameObject);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}
}
