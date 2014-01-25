using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	public int lives;
	public int fullHealth;
	public float damageMultiplier;
	public float armor;
    public ParticleSystem BloodSpill;

	public int health;

	// Use this for initialization
    private void Start()
    {
        health = fullHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.collider.gameObject.layer == LayerMask.NameToLayer("Bullet")
            && GetComponent<PlayerScript>().bullet != collision.collider.GetComponent<BulletScript>())
		{
			var mag = collision.relativeVelocity.magnitude;
			if (mag > armor)
			{
				//Esko
				transform.GetComponentInChildren<PlayerAnimatorControllerScript>().gotHit = true;
				//Esko

				health -= (int)(damageMultiplier * (mag - armor));
			    BloodSpill.transform.position = collision.contacts[0].point;
			    BloodSpill.Play();
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
