using UnityEngine;
using System.Collections;

public class GravityControllerScript : MonoBehaviour {

	public Transform[] bullets = new Transform[2];
	public Transform[] players = new Transform[2];

	public float gravityMagnitude;

	// Use this for initialization
	void Start () {
		bullets [0].GetComponent<GravityScript> ().gravityDir = new Vector2 (0, -1);
	}

	public void SetGravity(int player) {
		Vector2 pos = bullets [player].transform.position;
		Collider2D collider = Physics2D.OverlapPoint (pos, 1 << 8);
		//if (Physics.Raycast (pos, new Vector3(0.0f, 0.0f, -1.0f), out hit) ) {
		if ( collider != null ) {
			bullets [player].GetComponent<GravityScript> ().gravityDir = collider.GetComponent<GravityAreaScript> ().gravityDir;
			players[player].GetComponent<GravityScript> ().gravityDir = collider.GetComponent<GravityAreaScript> ().gravityDir;
		} else{
			Debug.Log ("Gravity collider not found!");
		}
	}

	void FixedUpdate()
	{
		bullets [0].GetComponent<GravityScript>().ApplyGravity (gravityMagnitude);
		players [0].GetComponent<GravityScript>().ApplyGravity (gravityMagnitude);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
