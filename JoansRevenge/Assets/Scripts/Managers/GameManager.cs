using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject test;
	public enum AttackType {Fire, Neutral, Faith};

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			Vector3 tPos = Input.GetTouch (0).position;
			Vector3 worldPos = new Vector3 (Camera.main.ScreenToWorldPoint (tPos).x, Camera.main.ScreenToWorldPoint (tPos).y, 0f);
			Instantiate (test, worldPos, Quaternion.identity);
		}*/
	}
}
