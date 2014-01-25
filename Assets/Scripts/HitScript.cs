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
<<<<<<< HEAD
	void Start () {
		health = fullHealth;

	}
=======
    private void Start()
    {
        health = fullHealth;
    }
>>>>>>> 6bc63f88186f0a1b2a9d5dbebbde211226933ea8

    void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.collider.gameObject.layer == LayerMask.NameToLayer("Bullet") )
		{
			var mag = collision.relativeVelocity.magnitude;
			if (mag > armor)
			{
				//Esko
				transform.GetComponentInChildren<PlayerAnimatorControllerScript>().gotHit = true;
				//Esko

				health -= (int)(damageMultiplier * (mag - armor));
<<<<<<< HEAD
				Debug.Log ( "HEALTH:" + health );
				//Esko
				if (health <= 0)
				{	
					transform.GetComponentInChildren<PlayerAnimatorControllerScript> ().Killed = true;
					while(transform.GetComponentInChildren<Animator>().animation.IsPlaying("death"))
					{
						;
					}
				
				}
				//Esko
=======
			    BloodSpill.transform.position = collision.contacts[0].point;
			    BloodSpill.Play();
>>>>>>> 6bc63f88186f0a1b2a9d5dbebbde211226933ea8
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {

			Debug.Log ("KILLED!!!!");
			lives--;
			health = fullHealth;
			//transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		}
		
		if (lives <= 0) {
			Destroy (transform.gameObject);
		}
	}


}
