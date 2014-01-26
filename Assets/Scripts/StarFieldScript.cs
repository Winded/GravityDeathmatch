using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarFieldScript : MonoBehaviour {
	
	public float speed = 2f;
	public float horizontalDirection = -1; //move from right to left
	public int id = 0;
	float camHeight = 0;
	float camWidth = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(speed * horizontalDirection * Time.deltaTime, 0, 0));
		//print ("kamera width" + camWidth);

		if (transform.position.x < (Camera.main.transform.position.x - camWidth/2 - transform.renderer.bounds.size.x))
		{
			jumpToRight();
		}
	}

	void Awake()
	{
		Camera cam = Camera.main;
		camHeight = 2f * cam.orthographicSize;
		camWidth = camHeight * cam.aspect;

		transform.Translate(
			new Vector3(Camera.main.transform.position.x - camWidth/2 + (transform.renderer.bounds.size.x * id), 0, transform.position.z));

	}

	void jumpToRight()
	{
		Debug.Log ("hyppy");
		transform.Translate(
			new Vector3((Camera.main.transform.position.x - camWidth/2) + (transform.renderer.bounds.size.x * 3), 0, transform.position.z));


	}
}
