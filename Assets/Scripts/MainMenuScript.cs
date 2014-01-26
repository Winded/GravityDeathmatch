using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public enum MenuState { MENU_MAIN, MENU_CREDITS };
	public float buttonWidth;
	public float creditsWidth;
	public Font thefont;
	public GUISkin creditsSkin;
	public GUISkin mainMenuSkin;
	//public GUIStyle style;

	MenuState menuState;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {

		//GUILayoutOption[] style = new GUILayoutOption[] { GUILayout.Width(buttonWidth), GUILayout.Height(50.0f) };


		if ( menuState == MenuState.MENU_MAIN) 
		{
			GUI.skin = mainMenuSkin;

			GUILayout.BeginArea(new Rect(Screen.width/2.0f - 750/2.0f, Screen.height - 350, 750, 750));
			GUILayout.BeginHorizontal();

			//GUI.BeginGroup(new Rect(0, 0, 250, 250));
			if ( GUILayout.Button("PLAY", GUILayout.Width(250)) ) {
				Application.LoadLevel("GravityDeathmatch");
			}
			//GUI.EndGroup();

			//GUI.BeginGroup(new Rect(0, 0, 250, 250));
			//GUI.Button (new Rect (25,25,100,30), "I am a Fixed Layout Button");
			if ( GUILayout.Button("CREDITS", GUILayout.Width(250)) ) {
				menuState = MenuState.MENU_CREDITS;
			}
			//GUI.EndGroup();

			//GUI.BeginGroup(new Rect(0, 0, 250, 250));
			if ( GUILayout.Button( "EXIT", GUILayout.Width(250) ) ) {
				Application.Quit();
			}
			//GUI.EndGroup();
			GUILayout.EndArea ();
			GUILayout.EndHorizontal();
		} else if ( menuState == MenuState.MENU_CREDITS ) 
		{
			GUI.skin = creditsSkin;
			GUILayout.BeginArea(new Rect(Screen.width/2.0f - creditsWidth/2.0f, Screen.height - 380, creditsWidth, 250));
			//GUIStyle style2 = new GUIStyle("TextArea");
			//style2.fontSize = 25;
			GUILayout.Label("Gravity Deathmatch was made at Global/Finnish Game Jam 2014 by:\n\nProgramming\nTimo Kellomäki, Antton Hytönen, Esko Vankka & Tuomas Salmi\n\nGraphics\nIlkka Tauriainen & Tuomas Salmi\n\nMusic\nAsko Pennanen\n\nSound effects\nJonne Kokkonen & Konstamikko Korhonen");
			GUILayout.EndArea ();

			GUILayout.BeginArea(new Rect(Screen.width/2.0f - buttonWidth/2.0f, Screen.height - 100, buttonWidth, 100));
			if ( GUILayout.Button("BACK") ) {
				menuState = MenuState.MENU_MAIN;
			}
			GUILayout.EndArea ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
