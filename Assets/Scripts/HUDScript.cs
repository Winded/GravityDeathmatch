using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	public Vector2 pos;
	public float barDisplay = 0;
	public Vector2 size = new Vector2(60,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	public Texture2D playerIcon;
	public Transform player;
	public GUISkin mySkin;
	//public int side = 0;	//0 = left, 1 = right
	public enum sideEnum {LEFT, RIGHT};
	public sideEnum side = sideEnum.LEFT;

	int extraOffset = 0;	//moves life sprites to right if the bar is on right
	// Use this for initialization
	void Start () {
		if (side == sideEnum.RIGHT) 
		{
			//put stuff to the right:
			pos.x = Screen.width - 175;
			extraOffset = 84;
		}
	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = (player.GetComponent<HitScript> ().health / player.GetComponent<HitScript> ().fullHealth);
		print (barDisplay);
		print (player.GetComponent<HitScript> ().health / player.GetComponent<HitScript> ().fullHealth);
	}

	void OnGUI()
	{

		GUI.skin = mySkin;
		int lives = (player.GetComponent<HitScript> ().lives);


		if (side == sideEnum.LEFT)
		{
			for (int i = 0; i < lives; i++) 
			{
				GUI.Box(new Rect (pos.x + 22*i + extraOffset, pos.y+32, 100, 100), playerIcon);	//face
			}
		}
		else
		{
			//generate life images to the right edge of the screen
			for (int i = 0; i < lives; i++) 
			{
				GUI.Box(new Rect (pos.x - 22*i + extraOffset, pos.y+32, 100, 100), playerIcon);	//face
			}
		}


		//healthbar
		GUI.BeginGroup (new Rect (pos.x-32, pos.y+20, size.x, size.y));	//healthbar
		GUI.Box (new Rect (0,0, size.x, size.y), progressBarEmpty);

		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y), progressBarFull);
		GUI.EndGroup ();	
		GUI.EndGroup ();

	
	}

}
