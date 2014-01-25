using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public Vector3 Stuff;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		
		transform.position = Camera.main.ViewportToWorldPoint (Stuff);
	}
}
