using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionContainer : MonoBehaviour {
	public Attack attack;
	bool dragged = false;

	[Range(1f, 10f)]public float returnSpeed;
	public AnimationCurve returnCurve;

	[HideInInspector]public DeckManager deckMan;
	[HideInInspector]public GameObject prefab;
	[HideInInspector]public Transform parentSlot;

	public IEnumerator ReturnToDeck()
	{
		if (parentSlot != null) 
		{
			Vector3 originPosition = transform.position;
			for (float i = 0; i <= 1f; i += returnSpeed * Time.deltaTime) 
			{
				transform.position = Vector3.Lerp (originPosition, parentSlot.position, returnCurve.Evaluate(i));
				yield return null;
			}
			transform.position = parentSlot.position;
			transform.parent = parentSlot;
		} 
		else 
		{
			Vector3 originPosition = transform.position;
			for (float i = 0; i <= 1f; i += returnSpeed * Time.deltaTime) 
			{
				transform.position = Vector3.Lerp (originPosition, DeckManager.orphanReturnPoint, returnCurve.Evaluate(i));
				yield return null;
			}
			AddSelfToDeck ();
			Destroy (gameObject);

		}
	}
		 

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ComboBar") 
		{
			ComboManager cBar = other.GetComponent<ComboManager> ();
			cBar.StartCoroutine (cBar.AddToCombo (this));
		}
	}

	public void BeginDrag()
	{
		dragged = true;
	}



	public void AddSelfToDeck() //when used or destroyed
	{
		deckMan.deck.Add (prefab);
	}
}
