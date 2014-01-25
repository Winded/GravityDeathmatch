using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public enum MenuState { MENU_MAIN, MENU_CREDITS };
	public float buttonWidth;

	//public GUIStyle style;

	MenuState menuState;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {

		//GUILayoutOption[] style = new GUILayoutOption[] { GUILayout.Width(buttonWidth), GUILayout.Height(50.0f) };

		GUIStyle style = new GUIStyle("button");
		style.fontSize = 40;

		if ( menuState == MenuState.MENU_MAIN) 
		{
			GUILayout.BeginArea(new Rect(Screen.width/2.0f - buttonWidth/2.0f, 100, buttonWidth, 600));
			if ( GUILayout.Button("Play", style) ) {
				Application.LoadLevel("GravityDeathmatch");
			}

			if ( GUILayout.Button("Credits", style ) ) {
				menuState = MenuState.MENU_CREDITS;
			}

			if ( GUILayout.Button("Exit", style ) ) {
				Application.Quit();
			}
			GUILayout.EndArea ();
		} else if ( menuState == MenuState.MENU_CREDITS ) 
		{
			GUILayout.BeginArea(new Rect(Screen.width/2.0f - 200, 100, 400, 400));
			GUIStyle style2 = new GUIStyle("Credits");
			style2.fontSize = 25;
			GUILayout.TextArea("Gravity Deathmatch was made at\nGlobal/Finnish Game Jam 2014 by:\nAsdf Jklo - coding\nQwerty Uiop - graphics", style2);
			GUILayout.EndArea ();

			GUILayout.BeginArea(new Rect(Screen.width/2.0f - buttonWidth/2.0f, 500, buttonWidth, 200));
			if ( GUILayout.Button("Back", style ) ) {
				menuState = MenuState.MENU_MAIN;
			}
			GUILayout.EndArea ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
