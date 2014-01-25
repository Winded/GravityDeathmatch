using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour {

	//public Transform bulletTestPrefab;
	public Camera thecamera;
	public Transform gravityController;

	public Transform[] players = new Transform[2];

	bool dragging;
	Vector2 startPos;
	// Use this for initialization
	void Start () {
		dragging = false;
	}


	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown (0) && !dragging ) {
			dragging = true;
			startPos = thecamera.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log ("down at " + startPos );
		} else if ( Input.GetMouseButtonUp(0) && dragging) {
			dragging = false;
			Vector2 liftPos = thecamera.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log ( "up at" + Input.mousePosition );
			players[0].GetComponent<PlayerScript>().Shoot(liftPos - startPos);
		}
/*
		if (Input.GetKeyDown ("space")) 
		{
			gravityController.GetComponent<GravityControllerScript>().SetGravity(0);
		}
*/
	}
}
