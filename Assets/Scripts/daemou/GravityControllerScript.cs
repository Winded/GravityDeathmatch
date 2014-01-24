using UnityEngine;
using System.Collections;

public class GravityControllerScript : MonoBehaviour {

	public Transform[] bullets = new Transform[2];

	// Use this for initialization
	void Start () {
		bullets [0].GetComponent<GravityAreaScript> ().gravityDir = new Vector2 (0, -1);
	}

	public void SetGravity(int player) {
		Debug.Log ("gravity setting");
		Vector2 pos = bullets [player].transform.position;
		Debug.Log ("Finding collider for " + pos);
		Collider2D collider = Physics2D.OverlapPoint (pos, 1 << 8);
		//if (Physics.Raycast (pos, new Vector3(0.0f, 0.0f, -1.0f), out hit) ) {
		if ( collider != null ) {
			bullets [player].GetComponent<GravityAreaScript> ().gravityDir = collider.GetComponent<GravityAreaScript> ().gravityDir;
			Debug.Log ("Collider: " + collider.name);
			Debug.Log ("Gravity now " + bullets [player].GetComponent<GravityAreaScript> ().gravityDir );
		} else{
			Debug.Log ("Gravity raycast missed!");
		}
	}

	void FixedUpdate()
	{
		bullets [0].rigidbody2D.AddForce (10.0f * bullets [0].GetComponent<GravityAreaScript> ().gravityDir.normalized);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
