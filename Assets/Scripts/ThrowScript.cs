using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour {

	bool dragging;
	Vector2 startPos;
	// Use this for initialization
	void Start () {
		dragging = false;
	}

	void shoot(Vector2 from, Vector2 delta) {

	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown (0) && !dragging ) {
			dragging = true;
			startPos = Input.mousePosition;
			Debug.Log ("down at " + startPos );
		} else if ( Input.GetMouseButtonUp(0) && dragging) {
			dragging = false;
			shoot(startPos, Input.mousePosition - startPos);
		}

	}
}
