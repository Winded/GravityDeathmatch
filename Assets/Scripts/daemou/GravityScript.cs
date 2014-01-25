using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	public Vector2 gravityDir;

	// Use this for initialization
	void Start () {
		gravityDir = new Vector2 (0.0f, -1.0f);	
	}

	public void ApplyGravity(float magnitude) {
		rigidbody2D.AddForce (magnitude * gravityDir.normalized);
	}

	void FixedUpdate() {
	}

	// Update is called once per frame
	void Update () {
	
	}
}
