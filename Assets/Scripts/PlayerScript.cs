using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Transform bullet;
	public float pickupDistance;
	public float pickupVelocity;

	// Use this for initialization
	void Start () {
		PutBulletOverhead ();
	}

	public void PutBulletOverhead()
	{
		Debug.Log ("overhead");
		bullet.GetComponent<BulletScript> ().IsAttached = true;
		//bullet.transform.position = new Vector3 (transform.position.x, transform.position.y, 0.0f) + 2.0f * transform.TransformDirection (0.0f, 1.0f, 0.0f);
		bullet.rigidbody2D.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		bullet.parent = transform;
		bullet.rigidbody2D.isKinematic = true;
		bullet.transform.rotation = Quaternion.identity;
		//bullet.transform.position = 2.0f * transform.TransformDirection (0.0f, 1.0f, 0.0f);
		bullet.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	public void Shoot(Vector2 from, Vector2 delta) {
		if ( bullet.GetComponent<BulletScript> ().IsAttached )
		{
			bullet.GetComponent<BulletScript> ().IsAttached = false;
			bullet.transform.parent = null;
			bullet.rigidbody2D.isKinematic = false;
			bullet.rigidbody2D.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
			bullet.rigidbody2D.AddForce ( new Vector2(100.0f * delta.x, 100.0f * delta.y) );
		}
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (bullet.GetComponent<BulletScript> ().IsAttached);

		if ( !bullet.GetComponent<BulletScript>().IsAttached &&
			Vector3.Distance ( bullet.transform.position, transform.position) < pickupDistance &&
			Vector3.Magnitude( bullet.rigidbody2D.velocity - rigidbody2D.velocity) < pickupVelocity)
		{
			Debug.Log("calling overhead");
			PutBulletOverhead();
		}
	}
}
