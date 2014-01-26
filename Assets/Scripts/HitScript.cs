using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {
	
	public int lives;
	public float fullHealth;
	public float damageMultiplier;
	public float armor;
    public ParticleSystem BloodSpill;

	public float health;

    private bool _Blinking;
    private float _BlinkStart;

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
				GetComponent<PlayerSoundEffectsHelper>().MakeGettingHitSound();
				transform.GetComponentInChildren<PlayerAnimatorControllerScript>().gotHit = true;
				//Esko
				
				health -= (int)(damageMultiplier * (mag - armor));
				Debug.Log ( "HEALTH:" + health );
				//Esko
				if (health <= 0)
				{	

					GetComponent<PlayerSoundEffectsHelper>().MakeDyingSound();
					transform.GetComponentInChildren<PlayerAnimatorControllerScript> ().Killed = true;

				}
				//Esko
			    BloodSpill.transform.position = collision.contacts[0].point;
			    BloodSpill.Play();
			}
		}
	}
	
	// Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("KILLED!!!!");
            lives--;
            health = fullHealth;
            transform.position = Vector3.zero;
            GetComponent<Controller2D>().MoveAngle = 0f;
            _Blinking = true;
            _BlinkStart = Time.time;
        }

        if (_Blinking && Time.time - _BlinkStart <= 2.5f)
        {
            if (Time.time%1 <= 0.5f)
            {
                print("BLINK ON");
                GetComponent<Controller2D>().sprite.enabled = false;
            }
            else
            {
                print("BLINK OFF");
                GetComponent<Controller2D>().sprite.enabled = true;
            }
        }
        else if (_Blinking)
        {
            GetComponent<Controller2D>().sprite.enabled = true;
            _Blinking = false;
        }

        if (lives <= 0)
        {
            GetComponent<Controller2D>().sprite.enabled = false;
            GetComponent<PlayerScript>().bullet.GetComponent<SpriteRenderer>().enabled = false;
            var gs = GameObject.FindGameObjectWithTag("GameState");
            gs.GetComponent<GameStateScript>().EndGame(GetComponent<PlayerScript>().playerID);
        }
    }


}
