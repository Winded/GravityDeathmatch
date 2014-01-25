using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	//public Vector2 gravityDir;
	public float gravityAngle;

	// Use this for initialization
	void Start () {
		//gravityAngle = 270.0f;
		//gravityDir = new Vector2 (0.0f, -1.0f);	
	}

	public void ApplyGravity(float magnitude) {
		//if (!rigidbody2D.isKinematic)
		//{
			rigidbody2D.AddForce (Vectors.RotateVector2(Vector2.right, gravityAngle) * magnitude );
		//}
	}

	void FixedUpdate() {
	}

	// Update is called once per frame
	void Update () {
	
	}
}
