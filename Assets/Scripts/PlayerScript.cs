using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Transform bullet;

	// Use this for initialization
	void Start () {
		PutBulletOverhead ();
	}

	public void PutBulletOverhead()
	{
		bullet.transform.position = new Vector3 (transform.position.x, transform.position.y, 0.0f) + 2.0f * transform.TransformDirection (0.0f, 1.0f, 0.0f);
	}

	public void Shoot(Vector2 from, Vector2 delta) {
		PutBulletOverhead ();
		bullet.rigidbody2D.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		bullet.rigidbody2D.AddForce ( new Vector2(100.0f * delta.x, 100.0f * delta.y) );
	}

	// Update is called once per frame
	void Update () {
	
	}
}
