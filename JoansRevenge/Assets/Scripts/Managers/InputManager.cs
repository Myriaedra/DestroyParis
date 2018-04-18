using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	public static bool dragging;
	Transform draggedAction;
	int dragTouchIndex;
	public LayerMask actionsLayer;
	public LayerMask qteLayer;
	[Range(0.5f, 1f)]
	public float dragCoeff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount > 0) 
		{
			//Get began !
			for (int i = 0; i < Input.touchCount; i++) 
			{
				if (Input.GetTouch (i).phase == TouchPhase.Began) 
				{
					Ray ray = new Ray (Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position), Camera.main.transform.forward);
					RaycastHit hit = new RaycastHit ();
					Debug.DrawRay (Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position), Camera.main.transform.forward, Color.green);

					//Detect Actions
					if (Physics.Raycast (ray, out hit, 100f, actionsLayer) && !dragging) 
					{
						dragTouchIndex = i;
						dragging = true;
						draggedAction = hit.collider.transform;
						draggedAction.parent = null;
					}

					//Detect QTE
					if (Physics.Raycast (ray, out hit, 100f, qteLayer)) 
					{
						
					}
				}
			}

			//Dragging an action
			if (dragging && (Input.GetTouch(dragTouchIndex).phase == TouchPhase.Moved || Input.GetTouch(dragTouchIndex).phase == TouchPhase.Stationary))
			{
				Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch(dragTouchIndex).position);
				draggedAction.position = Vector3.Lerp (draggedAction.position, new Vector3 (worldPos.x, worldPos.y, 0f), dragCoeff);
			}
			
			//End dragging
			if (dragging && (Input.GetTouch(dragTouchIndex).phase == TouchPhase.Ended || Input.GetTouch(dragTouchIndex).phase == TouchPhase.Ended)) 
			{
				dragging = false;
				//if not placed
				StartCoroutine (draggedAction.GetComponent<ActionContainer> ().ReturnToDeck());
				draggedAction = null;
			}
		}
	}
}
