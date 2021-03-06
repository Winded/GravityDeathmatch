﻿using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {

	public enum GameState { GAMESTATE_PLAYING, GAMESTATE_PAUSED, GAMESTATE_ENDED };
	public GameState gameState;

    public SpriteRenderer EndGamePlayer1;
    public SpriteRenderer EndGamePlayer2;
    public MeshRenderer EndGameInstruction;
    public AudioSource MusicPlayer;
    public AudioSource EndGameFunfar;
    public AudioClip EndGamePlayerClip;
    public AudioClip EndGameAlienClip;

	float buttonWidth = 250.0f;

	// Use this for initialization
	void Start () {
		gameState = GameState.GAMESTATE_PLAYING;
	}

	public void Pause()
	{
		Time.timeScale = 0;
		gameState = GameState.GAMESTATE_PAUSED;
	}

	public void ContinuePlaying()
	{
		//Debug.Log ("continuing playing");
		Time.timeScale = 1;
		gameState = GameState.GAMESTATE_PLAYING;
	}

    public void EndGame(int winner)
    {
        AudioClip clip;
        gameState = GameState.GAMESTATE_ENDED;
        if (winner == 1)
        {
            EndGamePlayer1.enabled = true;
            clip = EndGamePlayerClip;
        }
        else
        {
            EndGamePlayer2.enabled = true;
            clip = EndGameAlienClip;
        }
        EndGameInstruction.enabled = true;
        EndGameFunfar.clip = clip;
        EndGameFunfar.Play();
        MusicPlayer.Stop();
    }

	void OnGUI() {
		GUIStyle style = new GUIStyle("button");
		style.fontSize = 20;

		if ( gameState == GameState.GAMESTATE_PAUSED ) 
		{
			//Debug.Log ("paused drawing menus");
			GUILayout.BeginArea(new Rect( Screen.width/2.0f - buttonWidth/2.0f, 
			                             Screen.height/2.0f - 100.0f, 
			                             buttonWidth, 
			                             200.0f));
			//GUILayout.BeginArea(new Rect(Screen.width/2.0f - buttonWidth/2.0f, Screen.height - 350, buttonWidth, 250));

			if ( GUILayout.Button("Quit" , style ) ) {
				ContinuePlaying();
				Application.LoadLevel(0);
				//Application.Quit();
			}
			
			if ( GUILayout.Button("Continue" , style  ) ) {
				ContinuePlaying();
			}

			GUILayout.EndArea ();
		}
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.Escape) )
		{
			if ( gameState == GameState.GAMESTATE_PAUSED)
			{
				//Debug.Log("calling contplay");
				ContinuePlaying();
			} else if ( gameState == GameState.GAMESTATE_PLAYING )
			{
				//Debug.Log ("calling pause");
				Pause ();
			}
		}
	    if (Input.GetKeyDown(KeyCode.Space) && gameState == GameState.GAMESTATE_ENDED)
	    {
	        Application.LoadLevel("GravityDeathmatch");
	    }
		//Debug.Log (gameState);
	}
}
