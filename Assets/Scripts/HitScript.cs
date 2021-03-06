﻿using UnityEngine;
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
			//Debug.Log ("collision: " + mag);
			if ( mag > armor && !_Blinking )
			{
				//Esko
				GetComponent<PlayerSoundEffectsHelper>().MakeGettingHitSound();
				transform.GetComponentInChildren<PlayerAnimatorControllerScript>().gotHit = true;
				//Esko
				
				health -= (int)(damageMultiplier * (mag - armor));
				//Debug.Log ( "HEALTH:" + health );
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
            //Debug.Log("KILLED!!!!");
            lives--;
            health = fullHealth;
            transform.position = Vector3.zero;
            GetComponent<Controller2D>().MoveAngle = 0f;
            _Blinking = true;
            _BlinkStart = Time.time;
			transform.FindChild("CarriedBullet").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (_Blinking && Time.time - _BlinkStart <= 2.5f)
        {
            if (Time.time%0.4f <= 0.2f)
            {
                //print("BLINK ON");
                GetComponent<Controller2D>().sprite.enabled = false;
            }
            else
            {
                //print("BLINK OFF");
                GetComponent<Controller2D>().sprite.enabled = true;
            }
        }
        else if (_Blinking)
        {
            GetComponent<Controller2D>().sprite.enabled = true;
			transform.FindChild("CarriedBullet").GetComponent<SpriteRenderer>().enabled = true;
			_Blinking = false;
        }

        var gs = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateScript>();
        if (lives <= 0 && gs.gameState != GameStateScript.GameState.GAMESTATE_ENDED)
        {
            GetComponent<Controller2D>().sprite.enabled = false;
            GetComponent<PlayerScript>().bullet.GetComponent<SpriteRenderer>().enabled = false;
            gs.EndGame(GetComponent<PlayerScript>().playerID);
        }
    }


}
