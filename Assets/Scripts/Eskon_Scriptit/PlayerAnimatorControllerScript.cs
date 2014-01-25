using UnityEngine;
using System.Collections;

public class PlayerAnimatorControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	public Vector2 currentVelocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = transform.parent.rigidbody2D.velocity.x;
		if (move > 0 && facingRight)
			Flip ();
		if (move < 0 && !facingRight)
			Flip ();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
