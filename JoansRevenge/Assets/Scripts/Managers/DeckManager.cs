using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour {
	public List<GameObject> deck;
	List<Transform> slots;
	[Range(0.1f,5f)]
	public float slidingSpeed;
	public static Vector3 orphanReturnPoint = new Vector3 (8f,7f,0f);
	public float spawnDelay;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnAction ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnAction()
	{
		//Create deck slot
		GameObject newSlot = new GameObject();
		newSlot.transform.parent = transform;
		newSlot.transform.localPosition = new Vector3 (0, -6f, 0);
		DeckSlot slot = newSlot.AddComponent<DeckSlot> ();
		slot.speed = slidingSpeed;

		//Choose at random in the deck and instantiate
		int r = Random.Range(0, deck.Count-1);
		GameObject spawned = Instantiate (deck [r], newSlot.transform);
		ActionContainer aC = spawned.GetComponent<ActionContainer> ();
		aC.deckMan = this;
		aC.prefab = deck [r];
		deck.RemoveAt (r);

		yield return new WaitForSeconds (spawnDelay);
		StartCoroutine(SpawnAction ());
	}
}
