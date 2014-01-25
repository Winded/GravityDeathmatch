using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	public int lives;
	public int fullHealth;
	public float damageMultiplier;
	public float armor;

	int health;

	// Use this for initialization
	void Start () {
		health = fullHealth;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.collider.gameObject.layer == LayerMask.NameToLayer("Bullet") )
		{
			var mag = collision.relativeVelocity.magnitude;
			if ( mag > armor) 
			{
				health -= (int)(damageMultiplier * (mag - armor));
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			lives--;
			health = fullHealth;
			transform.position = new Vector3(0.0f, 0.0f, 0.0f);
		}

		if (lives <= 0)
		{
		    Destroy(transform.gameObject);
		}
	}
}
