using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public BulletScript bullet;
	public float pickupDistance;
	public float pickupVelocity;
	public Transform carriedBullet;
	public float maxShootPower;
	public float shootMultiplier;
	public int playerID;


	public float shootDown;

    public float TimeUntilAutoPickup = 5f;
	public float TimeUntilShootPickup = 0.12f;
    private float _AutoPickupTime;
	private float _ShootPickupTime;

	// Use this for initialization
	void Start () {
		PutBulletOverhead ();
	}

	public void PutBulletOverhead()
	{
		Debug.Log ("Putting bullet overhead");
		bullet.gameObject.SetActive (false);
		bullet.IsAttached = true;

		carriedBullet.gameObject.SetActive (true);

		//bullet.transform.position = new Vector3 (transform.position.x, transform.position.y, 0.0f) + 2.0f * transform.TransformDirection (0.0f, 1.0f, 0.0f);
		//bullet.rigidbody2D.isKinematic = true;
		//bullet.rigidbody2D.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		//bullet.parent = transform;

		//bullet.transform.rotation = Quaternion.identity;
		//bullet.transform.position = 2.0f * transform.TransformDirection (0.0f, 1.0f, 0.0f);
		//bullet.transform.localPosition = new Vector3 (0.0f, 2.0f, 0.0f);
	}

	public void ActionDown()
	{
		if (!bullet.GetComponent<BulletScript> ().IsAttached) 
		{
			GameObject.Find("GravityController").GetComponent<GravityControllerScript>().SetGravity(playerID);
		}
	}

	public void ActionHeld()
	{
		if (bullet.GetComponent<BulletScript> ().IsAttached) 
		{
			shootDown += Time.deltaTime;
		} 
	}

	public void ActionUp(Vector2 input)
	{
		if (bullet.GetComponent<BulletScript> ().IsAttached) 
		{
			// Esko
			transform.GetComponent<PlayerSoundEffectsHelper>().MakeShootingSound();
			//Esko

			float angle = transform.GetComponent<Controller2D>().MoveAngle;

			input.y += 1.0f;
			Vector2 shootDir = Vectors.RotateVector2(input, angle);

			float shootPower = Mathf.Min( shootMultiplier * shootDown, maxShootPower );
			Shoot ( rigidbody2D.velocity + shootPower * shootDir );
			shootDown = 0.0f;
		}
	}

	public void Shoot(Vector2 delta) {

		if ( bullet.GetComponent<BulletScript> ().IsAttached )
		{
			carriedBullet.gameObject.SetActive(false);
			bullet.gameObject.SetActive(true);
			bullet.GetComponent<BulletScript> ().IsAttached = false;
			//bullet.transform.parent = null;
			//bullet.rigidbody2D.isKinematic = false;
			float angle = transform.GetComponent<Controller2D>().MoveAngle;
			Vector2 offset = Vectors.RotateVector2(new Vector3( 0.0f, 2.0f), angle);
			bullet.transform.position = transform.position + new Vector3( offset.x, offset.y, 0.0f );
		    bullet.rigidbody2D.velocity = Vector3.zero;
			bullet.rigidbody2D.AddForce ( new Vector2(100.0f * delta.x, 100.0f * delta.y) );
		    _AutoPickupTime = Time.time + TimeUntilAutoPickup;
			_ShootPickupTime = Time.time + TimeUntilShootPickup;
			Debug.Log("Shot with " + delta);
		}
	}

	// Update is called once per frame
	void Update () {
		if (IsBulletPickable() ||
            IsAutoPickupTime())
		{
			PutBulletOverhead();
		}

		if (Vector3.Distance (bullet.transform.position, transform.position) >= 40.0f)
		{
			Debug.Log ("Bullet out of field, fixing");
			PutBulletOverhead();
		}
	}

    public bool IsBulletPickable()
    {
			return !bullet.GetComponent<BulletScript>().IsAttached &&
				Time.time >= _ShootPickupTime &&
               Vector3.Distance(bullet.transform.position, transform.position) < pickupDistance &&
               Vector3.Magnitude(bullet.rigidbody2D.velocity - rigidbody2D.velocity) < pickupVelocity;
    }

    public bool IsAutoPickupTime()
    {
		//if ( playerID == 1 ) Debug.Log (_AutoPickupTime + " " + Time.time);

        return !bullet.GetComponent<BulletScript>().IsAttached &&
               Time.time >= _AutoPickupTime;
    }
}
