using UnityEngine;
using System.Collections;

public class GravityControllerScript : MonoBehaviour {

	public Transform[] bullets = new Transform[2];
	public Transform[] players = new Transform[2];

	public float gravityMagnitude;

	// Use this for initialization
	void Start () {
		float p0startAngle = 180.0f;
		float p1startAngle = 0.0f;

		bullets [0].GetComponent<GravityScript> ().gravityAngle = p0startAngle;
		players [0].GetComponent<GravityScript> ().gravityAngle = p0startAngle;
		players[0].GetComponent<Controller2D>().MoveAngle = (p0startAngle + 90) % 360;
		players[1].transform.rotation = Quaternion.Euler (new Vector3(0.0f, 0.0f, (p0startAngle - 90.0f) % 360.0f));

		bullets [1].GetComponent<GravityScript> ().gravityAngle = p1startAngle;
		players [1].GetComponent<GravityScript> ().gravityAngle = p1startAngle;
		players[1].GetComponent<Controller2D>().MoveAngle = (p1startAngle + 90) % 360;
		players[1].transform.rotation = Quaternion.Euler (new Vector3(0.0f, 0.0f, (p1startAngle - 90.0f) % 360.0f));
	}

	public void SetGravity(int player) {
		//Esko
		players[player].GetComponent<PlayerSoundEffectsHelper>().MakeChangeGravitySound();
		//Esko
		Vector2 pos = bullets [player].transform.position;
		Collider2D collider = Physics2D.OverlapPoint (pos, 1 << LayerMask.NameToLayer("Octagonsector"));
		//if (Physics.Raycast (pos, new Vector3(0.0f, 0.0f, -1.0f), out hit) ) {
		if ( collider != null ) {
			var gravityAngle = collider.GetComponent<GravityAreaScript> ().gravityAngle;
			bullets [player].GetComponent<GravityScript> ().gravityAngle = gravityAngle;
			players[player].GetComponent<GravityScript> ().gravityAngle = gravityAngle;
			players[player].GetComponent<Controller2D>().MoveAngle = (gravityAngle + 90) % 360;
		} else{
			Debug.Log ("Gravity collider not found!");
		}
	}

	void FixedUpdate()
	{
		bullets [0].GetComponent<GravityScript>().ApplyGravity (gravityMagnitude * Time.fixedDeltaTime);
		bullets [1].GetComponent<GravityScript>().ApplyGravity (gravityMagnitude * Time.fixedDeltaTime);
		players [0].GetComponent<GravityScript>().ApplyGravity (gravityMagnitude * Time.fixedDeltaTime);
		players [1].GetComponent<GravityScript>().ApplyGravity (gravityMagnitude * Time.fixedDeltaTime);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
