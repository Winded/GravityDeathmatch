using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	public Vector2 pos;
	public float barDisplay = 0;
	public Vector2 size = new Vector2(60,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	public Transform player;
	public GUISkin mySkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = (player.GetComponent<HitScript> ().health / player.GetComponent<HitScript> ().fullHealth);
		print (barDisplay);
		print (player.GetComponent<HitScript> ().health / player.GetComponent<HitScript> ().fullHealth);
	}

	void OnGUI()
	{
		//GUI.Box(new Rect(10,10,100,25), "Loader Menu");
		GUI.skin = mySkin;
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y), progressBarEmpty);
		
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y), progressBarFull);
		GUI.EndGroup ();
		
		GUI.EndGroup ();

		/*if (GUI.Button (new Rect (10,10,150,100), "I am a button")) 
		{
			print ("You clicked the button!");
		}*/
	}

}
