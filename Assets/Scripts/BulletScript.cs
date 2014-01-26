using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public bool IsAttached;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	//Esko
	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Octagon") && collision.relativeVelocity.magnitude > 6) {
			GeneralSoundEffectsHelper.Instance.MakeMissedShotSound();

		}
	}
	//Esko
}
