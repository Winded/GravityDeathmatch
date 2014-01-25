using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {
	
	public int lives;
	public float fullHealth;
	public float damageMultiplier;
	public float armor;
    public ParticleSystem BloodSpill;

	public float health;

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
			Debug.Log ("collision: " + mag);
			if ( mag > armor) 
			{
				//Esko
				transform.GetComponentInChildren<PlayerAnimatorControllerScript>().gotHit = true;
				//Esko
				
				health -= (int)(damageMultiplier * (mag - armor));
				Debug.Log ( "HEALTH:" + health );
				//Esko
				if (health <= 0)
				{	
					transform.GetComponentInChildren<PlayerAnimatorControllerScript> ().Killed = true;

				}
				//Esko
			    BloodSpill.transform.position = collision.contacts[0].point;
			    BloodSpill.Play();
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
