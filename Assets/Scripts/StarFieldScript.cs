using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarFieldScript : MonoBehaviour {
	
	public float speed = 2f;
	public float horizontalDirection = -1; //move from right to left
	public int id = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(speed * horizontalDirection * Time.deltaTime, 0, 0));

		if (transform.position.x < -transform.renderer.bounds.size.x)
		{
			jumpToRight();
		}
	}

	void Awake()
	{
		transform.Translate(
			new Vector3(0 + transform.renderer.bounds.size.x * id, 0, transform.position.z));

	}

	void jumpToRight()
	{
		//when the first BG on the list exit the barrier trigger, this snippet is called
		Debug.Log ("hyppy");
		transform.Translate(
			new Vector3(0 + transform.renderer.bounds.size.x * 2, 0, transform.position.z));


	}
}
