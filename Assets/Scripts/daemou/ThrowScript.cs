using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour {

	//public Transform bulletTestPrefab;
	public Camera thecamera;
	public Transform gravityController;

	public Transform bullet;

	bool dragging;
	Vector2 startPos;
	// Use this for initialization
	void Start () {
		dragging = false;
	}

	void Shoot(Vector2 from, Vector2 delta) {
		bullet.transform.position = new Vector3 (from.x, from.y, 0.0f);
		bullet.rigidbody2D.AddForce ( new Vector2(100.0f * delta.x, 100.0f * delta.y) );
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
			Shoot(startPos, liftPos - startPos);
		}

		if (Input.GetKeyDown ("space")) 
		{
			gravityController.GetComponent<GravityControllerScript>().SetGravity(0);
		}

	}
}
